using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace LanguageServer
{
    internal abstract class HandlerProvider
    {
        internal abstract RequestHandlerDelegate CreateRequestHandlerDelegate(MethodInfo method);
        internal abstract NotificationHandlerDelegate CreateNotificationHandlerDelegate(MethodInfo method);

        internal void AddHandlers(Handlers handlers, Type type)
        {
            var methodCallType = typeof(MethodCall).GetTypeInfo();
            foreach (var method in type.GetRuntimeMethods())
            {
                var rpcMethod = method.GetCustomAttribute<JsonRpcMethodAttribute>()?.Method;
                if (rpcMethod != null)
                {
                    AddHandler(handlers, method, rpcMethod);
                }
            }
        }

        internal void AddHandler(Handlers handlers, MethodInfo method, string rpcMethod)
        {
            if (IsRequestHandler(method))
            {
                var requestHandlerDelegate = CreateRequestHandlerDelegate(method);
                var requestHandler = new RequestHandler(rpcMethod, GetRequestType(method), GetResponseType(method), requestHandlerDelegate);
                handlers.AddRequestHandler(requestHandler);
            }
            else if (IsNotificationHandler(method))
            {
                var notificationHandlerDelegate = CreateNotificationHandlerDelegate(method);
                var notificationHandler = new NotificationHandler(rpcMethod, GetNotificationType(method), notificationHandlerDelegate);
                handlers.AddNotificationHandler(notificationHandler);
            }
        }

        internal bool IsRequestHandler(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length > 1) return false;
            if (parameters[0].IsIn) return false;
            var retType = method.ReturnType;
            if (retType == typeof(void)) return false;
            var openRetType = retType.GetGenericTypeDefinition();
            return (openRetType == typeof(Result<,>)) || (openRetType == typeof(VoidResult<>));
        }

        internal bool IsNotificationHandler(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length > 1) return false;
            if (parameters[0].IsIn) return false;
            var retType = method.ReturnType;
            return (retType == typeof(void));
        }

        internal Type GetRequestType(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                return typeof(VoidRequestMessage);
            }
            else if (parameters.Length == 1)
            {
                return typeof(RequestMessage<>).MakeGenericType(parameters[0].ParameterType);
            }
            else
            {
                return null;
            }
        }

        internal Type GetResponseType(MethodInfo method)
        {
            var retType = method.ReturnType;
            var openRetType = retType.GetGenericTypeDefinition();
            if (openRetType == typeof(Result<,>))
            {
                return typeof(ResponseMessage<,>).MakeGenericType(retType.GenericTypeArguments[0], retType.GenericTypeArguments[1]);
            }
            else if (openRetType == typeof(VoidResult<>))
            {
                return typeof(VoidResponseMessage<>).MakeGenericType(retType.GenericTypeArguments[0]);
            }
            else
            {
                return null;
            }
        }

        internal Type GetNotificationType(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                return typeof(VoidNotificationMessage);
            }
            else if (parameters.Length ==1)
            {
                return typeof(NotificationMessage<>).MakeGenericType(parameters[0].ParameterType);
            }
            else
            {
                return null;
            }
        }
    }

    internal class ServiceHandlerProvider : HandlerProvider
    {
        private static RequestHandlerDelegate ForRequest4<TService, TParams, TResult, TResponseError>(MethodInfo method)
            where TService : JsonRpcService, new()
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<TService, TParams, Result<TResult, TResponseError>>);
            var func = (Func<TService, TParams, Result<TResult, TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (RequestMessage<TParams>)r;
                var svc = new TService();
                svc.Connection = c;
                svc.CancellationToken = t;
                Result<TResult, TResponseError> result;
                try
                {
                    result = func(svc, request.@params);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    result = Result<TResult, TResponseError>.Error(Message.InternalError<TResponseError>());
                }
                return new ResponseMessage<TResult, TResponseError>
                {
                    id = request.id,
                    result = result.SuccessValue,
                    error = result.ErrorValue
                };
            };
        }

        private static MethodInfo GetFactoryForRequest4(MethodInfo method, Type serviceType, Type paramsType, Type resultType, Type responseErrorType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest4)).MakeGenericMethod(serviceType, paramsType, resultType, responseErrorType);
        }

        private static RequestHandlerDelegate ForRequest3<TService, TResult, TResponseError>(MethodInfo method)
            where TService : JsonRpcService, new()
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<TService, Result<TResult, TResponseError>>);
            var func = (Func<TService, Result<TResult, TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                var svc = new TService();
                svc.Connection = c;
                svc.CancellationToken = t;
                Result<TResult, TResponseError> result;
                try
                {
                    result = func(svc);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    result = Result<TResult, TResponseError>.Error(Message.InternalError<TResponseError>());
                }
                return new ResponseMessage<TResult, TResponseError>
                {
                    id = request.id,
                    result = result.SuccessValue,
                    error = result.ErrorValue
                };
            };
        }

        private static MethodInfo GetFactoryForRequest3(MethodInfo method, Type serviceType, Type resultType, Type responseErrorType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest3)).MakeGenericMethod(serviceType, resultType, responseErrorType);
        }

        private static RequestHandlerDelegate ForRequest2<TService, TResponseError>(MethodInfo method)
            where TService : JsonRpcService, new()
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<TService, VoidResult<TResponseError>>);
            var func = (Func<TService, VoidResult<TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                var svc = new TService();
                svc.Connection = c;
                svc.CancellationToken = t;
                VoidResult<TResponseError> result;
                try
                {
                    result = func(svc);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    result = VoidResult<TResponseError>.Error(Message.InternalError<TResponseError>());
                }
                return new VoidResponseMessage<TResponseError>
                {
                    id = request.id,
                    error = result.ErrorValue
                };
            };
        }

        private static MethodInfo GetFactoryForRequest2(MethodInfo method, Type serviceType, Type responseErrorType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest2)).MakeGenericMethod(serviceType, responseErrorType);
        }

        private static NotificationHandlerDelegate ForNotification2<TService, TParams>(MethodInfo method)
            where TService : JsonRpcService, new()
        {
            var deleType = typeof(Action<TService, TParams>);
            var action = (Action<TService, TParams>)method.CreateDelegate(deleType);

            return (n, c) =>
            {
                var notification = (NotificationMessage<TParams>)n;
                var svc = new TService();
                svc.Connection = c;
                try
                {
                    action(svc, notification.@params);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private static MethodInfo GetFactoryForNotification2(MethodInfo method, Type serviceType, Type paramsType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForNotification2)).MakeGenericMethod(serviceType, paramsType);
        }

        private static NotificationHandlerDelegate ForNotification1<TService>(MethodInfo method)
            where TService : JsonRpcService, new()
        {
            var deleType = typeof(Action<TService>);
            var action = (Action<TService>)method.CreateDelegate(deleType);

            return (n, c) =>
            {
                var notification = (VoidNotificationMessage)n;
                var svc = new TService();
                svc.Connection = c;
                try
                {
                    action(svc);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private static MethodInfo GetFactoryForNotification1(MethodInfo method, Type serviceType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForNotification1)).MakeGenericMethod(serviceType);
        }

        internal override RequestHandlerDelegate CreateRequestHandlerDelegate(MethodInfo method)
        {
            var serviceType = method.DeclaringType;
            var argTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
            Type argType = null;
            if (argTypes.Length > 1)
            {
                return null;
            }
            else if (argTypes.Length == 1)
            {
                argType = argTypes[0];
            }
            var returnType = method.ReturnType;
            var openReturnType = returnType.GetGenericTypeDefinition();
            Type resultType = null;
            Type responseErrorType = null;
            if (openReturnType == typeof(Result<,>))
            {
                resultType = returnType.GenericTypeArguments[0];
                responseErrorType = returnType.GenericTypeArguments[1];
            }
            else if (returnType.GetGenericTypeDefinition() == typeof(VoidResult<>))
            {
                responseErrorType = returnType.GenericTypeArguments[0];
            }
            var factory =
                (argType != null && resultType != null && responseErrorType != null) ? GetFactoryForRequest4(method, serviceType, argType, resultType, responseErrorType) :
                (argType == null && resultType != null && responseErrorType != null) ? GetFactoryForRequest3(method, serviceType, resultType, responseErrorType) :
                (argType == null && resultType == null && responseErrorType != null) ? GetFactoryForRequest2(method, serviceType, responseErrorType) :
                null;
            if (factory == null)
            {
                return null;
            }
            return (RequestHandlerDelegate)factory.Invoke(null, new object[] { method });
        }

        internal override NotificationHandlerDelegate CreateNotificationHandlerDelegate(MethodInfo method)
        {
            var serviceType = method.DeclaringType;
            var argTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
            Type paramsType = null;
            if (argTypes.Length > 1)
            {
                return null;
            }
            else if (argTypes.Length == 1)
            {
                paramsType = argTypes[0];
            }
            var returnType = method.ReturnType;
            var factory =
                (paramsType != null && returnType == null) ? GetFactoryForNotification2(method, serviceType, paramsType) :
                (paramsType == null && returnType == null) ? GetFactoryForNotification1(method, serviceType) :
                null;
            if (factory == null)
            {
                return null;
            }
            return (NotificationHandlerDelegate)factory.Invoke(null, new object[] { method });
        }
    }

    internal class ConnectionHandlerProvider : HandlerProvider
    {
        private static RequestHandlerDelegate ForRequest4<TConnection, TParams, TResult, TResponseError>(MethodInfo method)
            where TConnection : ServiceConnection
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<TConnection, TParams, Result<TResult, TResponseError>>);
            var func = (Func<TConnection, TParams, Result<TResult, TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (RequestMessage<TParams>)r;
                var connection = (TConnection)c;
                connection.CancellationToken = t;
                try
                {
                    Result<TResult, TResponseError> result;
                    try
                    {
                        result = func(connection, request.@params);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        result = Result<TResult, TResponseError>.Error(Message.InternalError<TResponseError>());
                    }
                    return new ResponseMessage<TResult, TResponseError>
                    {
                        id = request.id,
                        result = result.SuccessValue,
                        error = result.ErrorValue
                    };
                }
                finally
                {
                    connection.CancellationToken = CancellationToken.None;
                }
            };
        }

        private static MethodInfo GetFactoryForRequest4(MethodInfo method, Type connectionType, Type argType, Type resultType, Type responseErrorType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest4)).MakeGenericMethod(connectionType, argType, resultType, responseErrorType);
        }

        private static RequestHandlerDelegate ForRequest3<TConnection, TResult, TResponseError>(MethodInfo method)
            where TConnection : ServiceConnection
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<TConnection, Result<TResult, TResponseError>>);
            var func = (Func<TConnection, Result<TResult, TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                var connection = (TConnection)c;
                connection.CancellationToken = t;
                try
                {
                    Result<TResult, TResponseError> result;
                    try
                    {
                        result = func(connection);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        result = Result<TResult, TResponseError>.Error(Message.InternalError<TResponseError>());
                    }
                    return new ResponseMessage<TResult, TResponseError>
                    {
                        id = request.id,
                        result = result.SuccessValue,
                        error = result.ErrorValue
                    };
                }
                finally
                {
                    connection.CancellationToken = CancellationToken.None;
                }
            };
        }

        private static MethodInfo GetFactoryForRequest3(MethodInfo method, Type connectionType, Type resultType, Type responseErrorType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest3)).MakeGenericMethod(connectionType, resultType, responseErrorType);
        }

        private static RequestHandlerDelegate ForRequest2<TConnection, TResponseError>(MethodInfo method)
            where TConnection : ServiceConnection
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<TConnection, VoidResult<TResponseError>>);
            var func = (Func<TConnection, VoidResult<TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                var connection = (TConnection)c;
                connection.CancellationToken = t;
                try
                {
                    VoidResult<TResponseError> result;
                    try
                    {
                        result = func(connection);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        result = VoidResult<TResponseError>.Error(Message.InternalError<TResponseError>());
                    }
                    return new VoidResponseMessage<TResponseError>
                    {
                        id = request.id,
                        error = result.ErrorValue
                    };
                }
                finally
                {
                    connection.CancellationToken = CancellationToken.None;
                }
            };
        }

        private static MethodInfo GetFactoryForRequest2(MethodInfo method, Type connectionType, Type responseErrorType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest2)).MakeGenericMethod(connectionType, responseErrorType);
        }

        private static NotificationHandlerDelegate ForNotification2<TConnection, TParams>(MethodInfo method)
            where TConnection : ServiceConnection
        {
            var deleType = typeof(Action<TConnection, TParams>);
            var action = (Action<TConnection, TParams>)method.CreateDelegate(deleType);

            return (n, c) =>
            {
                var notification = (NotificationMessage<TParams>)n;
                var connection = (TConnection)c;
                try
                {
                    action(connection, notification.@params);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private static MethodInfo GetFactoryForNotification2(MethodInfo method, Type connectionType, Type paramsType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForNotification2)).MakeGenericMethod(connectionType, paramsType);
        }

        private static NotificationHandlerDelegate ForNotification1<TConnection>(MethodInfo method)
            where TConnection : ServiceConnection
        {
            var deleType = typeof(Action<TConnection>);
            var action = (Action<TConnection>)method.CreateDelegate(deleType);

            return (n, c) =>
            {
                var notification = (VoidNotificationMessage)n;
                var connection = (TConnection)c;
                try
                {
                    action(connection);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private static MethodInfo GetFactoryForNotification1(MethodInfo method, Type connectionType)
        {
            return typeof(ServiceHandlerProvider).GetTypeInfo().GetDeclaredMethod(nameof(ForNotification1)).MakeGenericMethod(connectionType);
        }

        internal override RequestHandlerDelegate CreateRequestHandlerDelegate(MethodInfo method)
        {
            var connectionType = method.DeclaringType;
            var argTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
            Type paramsType = null;
            if (argTypes.Length > 1)
            {
                return null;
            }
            else if (argTypes.Length == 1)
            {
                paramsType = argTypes[0];
            }
            var returnType = method.ReturnType;
            var openReturnType = returnType.GetGenericTypeDefinition();
            Type resultType = null;
            Type responseErrorType = null;
            if (openReturnType == typeof(Result<,>))
            {
                resultType = returnType.GenericTypeArguments[0];
                responseErrorType = returnType.GenericTypeArguments[1];
            }
            else if (returnType.GetGenericTypeDefinition() == typeof(VoidResult<>))
            {
                responseErrorType = returnType.GenericTypeArguments[0];
            }
            var factory =
                (paramsType != null && resultType != null && responseErrorType != null) ? GetFactoryForRequest4(method, connectionType, paramsType, resultType, responseErrorType) :
                (paramsType == null && resultType != null && responseErrorType != null) ? GetFactoryForRequest3(method, connectionType, resultType, responseErrorType) :
                (paramsType == null && resultType == null && responseErrorType != null) ? GetFactoryForRequest2(method, connectionType, responseErrorType) :
                null;
            if (factory == null)
            {
                return null;
            }
            return (RequestHandlerDelegate)factory.Invoke(null, new object[] { method });
        }

        internal override NotificationHandlerDelegate CreateNotificationHandlerDelegate(MethodInfo method)
        {
            var connectionType = method.DeclaringType;
            var argTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
            Type paramsType = null;
            if (argTypes.Length > 1)
            {
                return null;
            }
            else if (argTypes.Length == 1)
            {
                paramsType = argTypes[0];
            }
            var returnType = method.ReturnType;
            var factory =
                (paramsType != null && returnType == null) ? GetFactoryForNotification2(method, connectionType, paramsType) :
                (paramsType == null && returnType == null) ? GetFactoryForNotification1(method, connectionType) :
                null;
            if (factory == null)
            {
                return null;
            }
            return (NotificationHandlerDelegate)factory.Invoke(null, new object[] { method });
        }
    }
}
