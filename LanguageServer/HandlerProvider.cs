using System;
using System.Reflection;
using System.Threading;

namespace LanguageServer
{
    internal abstract class HandlerProvider
    {
        internal void AddHandlers(RequestHandlerCollection requestHandlers, NotificationHandlerCollection notificationHandlers, Type type)
        {
            var methodCallType = typeof(MethodCall).GetTypeInfo();
            foreach (var method in type.GetRuntimeMethods())
            {
                var rpcMethod = method.GetCustomAttribute<JsonRpcMethodAttribute>()?.Method;
                if (rpcMethod != null)
                {
                    if (Reflector.IsRequestHandler(method))
                    {
                        var requestHandlerDelegate = Reflector.CreateRequestHandlerDelegate(type, method, this);
                        var requestHandler = new RequestHandler(rpcMethod, Reflector.GetRequestType(method),
                            Reflector.GetResponseType(method), requestHandlerDelegate);
                        requestHandlers.AddRequestHandler(requestHandler);
                    }
                    else if (Reflector.IsNotificationHandler(method))
                    {
                        var notificationHandlerDelegate =
                            Reflector.CreateNotificationHandlerDelegate(type, method, this);
                        var notificationHandler = new NotificationHandler(rpcMethod,
                            Reflector.GetNotificationType(method), notificationHandlerDelegate);
                        notificationHandlers.AddNotificationHandler(notificationHandler);
                    }
                }
            }
        }

        internal abstract object CreateTargetObject(Type targetType, Connection connection, CancellationToken token);

        internal abstract object CreateTargetObject(Type targetType, Connection connection);
    }

    internal class ServiceHandlerProvider : HandlerProvider
    {
        internal override object CreateTargetObject(Type targetType, Connection connection, CancellationToken token)
        {
            var svc = (Service)Activator.CreateInstance(targetType);
            svc.Connection = connection;
            svc.CancellationToken = token;
            return svc;
        }

        internal override object CreateTargetObject(Type targetType, Connection connection)
        {
            var svc = (Service)Activator.CreateInstance(targetType);
            svc.Connection = connection;
            return svc;
        }
    }

    internal class ConnectionHandlerProvider : HandlerProvider
    {
        internal override object CreateTargetObject(Type targetType, Connection connection, CancellationToken token)
        {
            var sc = (ServiceConnection)connection;
            sc.CancellationToken = token;
            return sc;
        }

        internal override object CreateTargetObject(Type targetType, Connection connection)
        {
            return connection;
        }
    }
}
