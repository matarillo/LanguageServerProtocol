using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LanguageServer
{
    internal class Reflector
    {
        private static readonly MethodInfo factoryForRequest
            = typeof(Reflector).GetTypeInfo().DeclaredMethods.FirstOrDefault(mi => mi.Name == nameof(ForRequest));

        private static RequestHandlerDelegate ForRequest<TService, TRequest, TResponse>(MethodInfo mi)
            where TService : JsonRpcService, new()
            where TRequest : MethodCall
            where TResponse : ResponseMessageBase
        {
            var deleType = typeof(Func<TService, TRequest, TResponse>);
            var func = (Func<TService, TRequest, TResponse>)mi.CreateDelegate(deleType);
            return (args, connection, token) =>
            {
                var svc = new TService();
                svc.Connection = connection;
                svc.CancellationToken = token;
                return func(svc, (TRequest)args);
            };
        }

        private static readonly MethodInfo factoryForNotification
            = typeof(Reflector).GetTypeInfo().DeclaredMethods.FirstOrDefault(mi => mi.Name == nameof(ForNotification));

        private static Action<object> ForNotification<TService, TRequest>(Connection connection, MethodInfo mi)
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

        private static RequestHandlerDelegate CreateRequestHandlerDelegate(Type serviceType, MethodInfo methodInfo)
        {
            var requestType = methodInfo.GetParameters()[0].ParameterType;
            var responseType = methodInfo.ReturnType;
            var factory = factoryForRequest.MakeGenericMethod(serviceType, requestType, responseType);
            var dele = (RequestHandlerDelegate)factory.Invoke(null, new object[] { methodInfo });
            return dele;
        }

        private static NotificationHandlerDelegate CreateNotificationHandlerDelegate(Type serviceType, MethodInfo methodInfo)
        {
            var requestType = methodInfo.GetParameters()[0].ParameterType;
            var factory = factoryForNotification.MakeGenericMethod(serviceType, requestType);
            var dele = (NotificationHandlerDelegate)factory.Invoke(null, new object[] { methodInfo });
            return dele;
        }

        private static RequestHandler CreateRequestHandler(string rpcMethod, Type serviceType, MethodInfo methodInfo)
        {
            var requestType = methodInfo.GetParameters()[0].ParameterType;
            var responseType = methodInfo.ReturnType;
            var dele = CreateRequestHandlerDelegate(serviceType, methodInfo);
            return new RequestHandler(rpcMethod, requestType, responseType, dele);
        }

        private static NotificationHandler CreateNotificationHandler(string rpcMethod, Type serviceType, MethodInfo methodInfo)
        {
            var requestType = methodInfo.GetParameters()[0].ParameterType;
            var dele = CreateNotificationHandlerDelegate(serviceType, methodInfo);
            return new NotificationHandler(rpcMethod, requestType, dele);
        }

        private IEnumerable<RequestHandler> _requestHandlers;
        private IEnumerable<NotificationHandler> _notificationHandlers;

        internal Reflector(Type serviceType)
        {
            var rpcType = typeof(JsonRpcService).GetTypeInfo();
            if (!rpcType.IsAssignableFrom(serviceType.GetTypeInfo()))
            {
                throw new ArgumentException("Specify a type derived from JsonRpcService", nameof(serviceType));
            }

            var methodCallType = typeof(MethodCall).GetTypeInfo();
            var methods = serviceType.GetRuntimeMethods()
                .Select(x => new
                {
                    MethodInfo = x,
                    RpcMethod = x.GetCustomAttribute<JsonRpcMethodAttribute>()?.Method,
                    Paremeters = x.GetParameters(),
                    ReturnType = x.ReturnType
                })
                .Where(x => x.RpcMethod != null
                    && x.Paremeters.Length == 1
                    && methodCallType.IsAssignableFrom(x.Paremeters[0].ParameterType.GetTypeInfo()));

            var responseType = typeof(ResponseMessageBase).GetTypeInfo();
            _requestHandlers = methods
                .Where(x => responseType.IsAssignableFrom(x.ReturnType.GetTypeInfo()))
                .Select(x => CreateRequestHandler(x.RpcMethod, serviceType, x.MethodInfo));
            _notificationHandlers = methods
                .Where(x => x.ReturnType == typeof(void))
                .Select(x => CreateNotificationHandler(x.RpcMethod, serviceType, x.MethodInfo));
        }

        internal IEnumerable<RequestHandler> RequestHandlers => _requestHandlers;
        internal IEnumerable<NotificationHandler> NotificationHandlers => _notificationHandlers;
    }
}
