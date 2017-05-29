using LanguageServer.Json;
using LanguageServer.Parameters.General;
using Matarillo.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageServer
{
    public class Connection
    {
        private ProtocolReader input;
        private const byte CR = (byte)13;
        private const byte LF = (byte)10;
        private readonly byte[] separator = { CR, LF };
        private Stream output;
        private readonly object outputLock = new object();
        private readonly Dictionary<string, RequestHandler> requestHandlers = new Dictionary<string, RequestHandler>();
        private readonly SyncDictionary<NumberOrString, ResponseHandler> responseHandlers = new SyncDictionary<NumberOrString, ResponseHandler>();
        private readonly Dictionary<string, NotificationHandler> notificationHandlers = new Dictionary<string, NotificationHandler>();
        private readonly SyncDictionary<NumberOrString, CancellationTokenSource> cancellations = new SyncDictionary<NumberOrString, CancellationTokenSource>();

        public Connection(Stream input, Stream output)
        {
            this.input = new ProtocolReader(input);
            this.output = output;
        }

        public async Task Start()
        {
            while (await ReadAndHandle())
            {
            }
        }

        private async Task<bool> ReadAndHandle()
        {
            var json = await Read();
            var messageTest = (MessageTest)Serializer.Instance.Deserialize(typeof(MessageTest), json);
            if (messageTest == null)
            {
                return false;
            }
            if (messageTest.IsRequest)
            {
                HandleRequest(messageTest.method, messageTest.id, json);
            }
            else if (messageTest.IsResponse)
            {
                HandleResponse(messageTest.id, json);
            }
            else if (messageTest.IsCancellation)
            {
                HandleCancellation(json);
            }
            else if (messageTest.IsNotification)
            {
                HandleNotification(messageTest.method, json);
            }
            return true;
        }

        private void HandleRequest(string method, NumberOrString id, string json)
        {
            if (requestHandlers.TryGetValue(method, out RequestHandler handler))
            {
                var tokenSource = new CancellationTokenSource();
                cancellations.Set(id, tokenSource);
                var request = Serializer.Instance.Deserialize(handler.RequestType, json);
                var requestResponse = (ResponseMessageBase)handler.Handle(request, tokenSource.Token);
                cancellations.Remove(id);
                requestResponse.id = id;
                SendMessage(requestResponse);
            }
        }

        private void HandleResponse(NumberOrString id, string json)
        {
            ResponseHandler handler;
            if (responseHandlers.TryRemove(id, out handler))
            {
                var response = Serializer.Instance.Deserialize(handler.ResponseType, json);
                handler.Handle(response);
            }
        }

        private void HandleCancellation(string json)
        {
            var cancellation = (NotificationMessage<CancelParams>)Serializer.Instance.Deserialize(typeof(NotificationMessage<CancelParams>), json);
            var id = cancellation.@params.id;
            CancellationTokenSource tokenSource;
            if (cancellations.TryRemove(id, out tokenSource))
            {
                tokenSource.Cancel();
            }
        }

        private void HandleNotification(string method, string json)
        {
            NotificationHandler handler;
            if (notificationHandlers.TryGetValue(method, out handler))
            {
                var notification = Serializer.Instance.Deserialize(handler.NotificationType, json);
                handler.Handle(notification);
            }
        }

        public void SendRequest<TReq, TRes, TError>(RequestMessage<TReq> message, Action<ResponseMessage<TRes, TError>> responseHandler)
            where TError : ResponseError
        {
            responseHandlers.Set(message.id, new ResponseHandler(typeof(ResponseMessage<TRes, TError>), o => responseHandler((ResponseMessage<TRes, TError>)o)));
            SendMessage(message);
        }

        public void SendNotification<T>(NotificationMessage<T> message)
        {
            SendMessage(message);
        }

        public void SendCancellation(NumberOrString id)
        {
            var message =  new NotificationMessage<CancelParams> { method = "$/cancelRequest", @params = new CancelParams { id = id } };
            SendMessage(message);
        }

        internal void AddRequestHandler(string method, RequestHandler requestHandler)
        {
            requestHandlers[method] = requestHandler;
        }

        internal void AddNotificationHandler(string method, NotificationHandler notificationHandler)
        {
            notificationHandlers[method] = notificationHandler;
        }

        private void SendMessage(Message message)
        {
            Write(Serializer.Instance.Serialize(typeof(Message), message));
        }

        private void Write(string json)
        {
            var utf8 = Encoding.UTF8.GetBytes(json);
            lock (outputLock)
            {
                using (var writer = new StreamWriter(output, Encoding.ASCII, 1024, true))
                {
                    writer.Write($"Content-Length: {utf8.Length}\r\n");
                    writer.Write("\r\n");
                    writer.Flush();
                }
                output.Write(utf8, 0, utf8.Length);
                output.Flush();
            }
        }

        private async Task<string> Read()
        {
            var contentLength = 0;
            var headerBytes = await input.ReadToSeparatorAsync(separator);
            while (headerBytes.Length != 0)
            {
                var headerLine = Encoding.ASCII.GetString(headerBytes);
                var position = headerLine.IndexOf(": ");
                if (position >= 0)
                {
                    var name = headerLine.Substring(0, position);
                    var value = headerLine.Substring(position + 2);
                    if (string.Equals(name, "Content-Length", StringComparison.Ordinal))
                    {
                        int.TryParse(value, out contentLength);
                    }
                }
                headerBytes = await input.ReadToSeparatorAsync(separator);
            }
            if (contentLength == 0)
            {
                return "";
            }
            var contentBytes = await input.ReadBytesAsync(contentLength);
            return Encoding.UTF8.GetString(contentBytes);
        }

        public void TestHandleRequest(string method, NumberOrString id, string json)
        {
            HandleRequest(method, id, json);
        }

        public void TestHandleNotification(string method, string json)
        {
            HandleNotification(method, json);
        }

        public void TestReadAndHandle()
        {
            ReadAndHandle().Wait();
        }

        public void AddDefinedJsonRpcMethods(Assembly targetAssembly)
        {
            var rpcType = typeof(JsonRpcService).GetTypeInfo();
            var methodCallType = typeof(MethodCall).GetTypeInfo();
            var serviceTypes = targetAssembly.DefinedTypes
                .Where(x => rpcType.IsAssignableFrom(x))
                .Select(x => x.AsType());
            foreach (var serviceType in serviceTypes)
            {
                var rpcMethods = serviceType.GetRuntimeMethods()
                    .Select(x => new
                    {
                        MethodInfo = x,
                        RpcMethodName = x.GetCustomAttribute<JsonRpcMethodAttribute>()?.Method,
                        Paremeters = x.GetParameters(),
                        ReturnType = x.ReturnType
                    })
                    .Where(x => x.RpcMethodName != null
                        && x.Paremeters.Length == 1
                        && methodCallType.IsAssignableFrom(x.Paremeters[0].ParameterType.GetTypeInfo()));
                foreach (var method in rpcMethods)
                {
                    if (method.ReturnType == typeof(void))
                    {
                        AddNotificationHandler(method.RpcMethodName, CreateNotificationHandler(serviceType, method.MethodInfo));
                    }
                    else
                    {
                        AddRequestHandler(method.RpcMethodName, CreateRequestHandler(serviceType, method.MethodInfo));
                    }
                }
            }
        }

        private RequestHandler CreateRequestHandler(Type serviceType, MethodInfo methodInfo)
        {
            var requestType = methodInfo.GetParameters()[0].ParameterType;
            var responseType = methodInfo.ReturnType;
            var factory = openFuncFactory.MakeGenericMethod(serviceType, requestType, responseType);
            var handler = (Func<object, CancellationToken, object>)factory.Invoke(null, new object[] { this, methodInfo });
            return new RequestHandler(requestType, responseType, handler);
        }

        private NotificationHandler CreateNotificationHandler(Type serviceType, MethodInfo methodInfo)
        {
            var requestType = methodInfo.GetParameters()[0].ParameterType;
            var factory = openActionFactory.MakeGenericMethod(serviceType, requestType);
            var handler = (Action<object>)factory.Invoke(null, new object[] { this, methodInfo });
            return new NotificationHandler(requestType, handler);
        }

        private static readonly MethodInfo openFuncFactory
            = typeof(Connection).GetTypeInfo().DeclaredMethods.FirstOrDefault(mi => mi.Name == nameof(CreateFunc));

        private static Func<object, CancellationToken, object> CreateFunc<TService, TRequest, TResponse>(Connection connection, MethodInfo mi)
            where TService : JsonRpcService, new()
            where TRequest : MethodCall
            where TResponse : ResponseMessageBase
        {
            var deleType = typeof(Func<TService, TRequest, TResponse>);
            var func = (Func<TService, TRequest, TResponse>)mi.CreateDelegate(deleType);
            return (args, token) =>
            {
                var svc = new TService();
                svc.Connection = connection;
                svc.CancellationToken = token;
                return func(svc, (TRequest)args);
            };
        }

        private static readonly MethodInfo openActionFactory
            = typeof(Connection).GetTypeInfo().DeclaredMethods.FirstOrDefault(mi => mi.Name == nameof(CreateAction));

        private static Action<object> CreateAction<TService, TRequest>(Connection connection, MethodInfo mi)
            where TService : JsonRpcService, new()
            where TRequest : MethodCall
        {
            var deleType = typeof(Action<TService, TRequest>);
            var action = (Action<TService, TRequest>)mi.CreateDelegate(deleType);
            return args =>
            {
                var svc = new TService();
                svc.Connection = connection;
                action(svc, (TRequest)args);
            };
        }
    }
}
