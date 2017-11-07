using System;
using System.Linq;
using System.Reflection;

namespace LanguageServer
{
    internal static class Reflector
    {
        internal static bool IsRequestHandler(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length > 1) return false;
            if (parameters.Length == 1 && parameters[0].IsIn) return false;
            var retType = method.ReturnType;
            if (retType == typeof(void)) return false;
            var openRetType = retType.GetGenericTypeDefinition();
            return (openRetType == typeof(Result<,>)) || (openRetType == typeof(VoidResult<>));
        }

        internal static bool IsNotificationHandler(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length > 1) return false;
            if (parameters.Length == 1 && parameters[0].IsIn) return false;
            var retType = method.ReturnType;
            return (retType == typeof(void));
        }

        internal static Type GetRequestType(MethodInfo method)
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

        internal static Type GetResponseType(MethodInfo method)
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

        internal static Type GetNotificationType(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                return typeof(VoidNotificationMessage);
            }
            else if (parameters.Length == 1)
            {
                return typeof(NotificationMessage<>).MakeGenericType(parameters[0].ParameterType);
            }
            else
            {
                return null;
            }
        }

        private static RequestHandlerDelegate ForRequest4<T, TParams, TResult, TResponseError>(Type targetType, MethodInfo method, HandlerProvider provider)
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<T, TParams, Result<TResult, TResponseError>>);
            var func = (Func<T, TParams, Result<TResult, TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (RequestMessage<TParams>)r;
                var target = provider.CreateTargetObject(targetType, c, t);
                Result<TResult, TResponseError> result;
                try
                {
                    result = func((T)target, request.@params);
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

        private static MethodInfo GetFactoryForRequest4(MethodInfo method, Type declaringType, Type paramsType, Type resultType, Type responseErrorType)
        {
            return typeof(Reflector).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest4)).MakeGenericMethod(declaringType, paramsType, resultType, responseErrorType);
        }

        private static RequestHandlerDelegate ForRequest3<T, TResult, TResponseError>(Type targetType, MethodInfo method, HandlerProvider provider)
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<T, Result<TResult, TResponseError>>);
            var func = (Func<T, Result<TResult, TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                var target = provider.CreateTargetObject(targetType, c, t);
                Result<TResult, TResponseError> result;
                try
                {
                    result = func((T)target);
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

        private static MethodInfo GetFactoryForRequest3(MethodInfo method, Type declaringType, Type resultType, Type responseErrorType)
        {
            return typeof(Reflector).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest3)).MakeGenericMethod(declaringType, resultType, responseErrorType);
        }

        private static RequestHandlerDelegate ForRequest2<T, TResponseError>(Type targetType, MethodInfo method, HandlerProvider provider)
            where TResponseError : ResponseError, new()
        {
            var deleType = typeof(Func<T, VoidResult<TResponseError>>);
            var func = (Func<T, VoidResult<TResponseError>>)method.CreateDelegate(deleType);

            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                var target = provider.CreateTargetObject(targetType, c, t);
                VoidResult<TResponseError> result;
                try
                {
                    result = func((T)target);
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

        private static MethodInfo GetFactoryForRequest2(MethodInfo method, Type declaringType, Type responseErrorType)
        {
            return typeof(Reflector).GetTypeInfo().GetDeclaredMethod(nameof(ForRequest2)).MakeGenericMethod(declaringType, responseErrorType);
        }

        private static NotificationHandlerDelegate ForNotification2<T, TParams>(Type targetType, MethodInfo method, HandlerProvider provider)
        {
            var deleType = typeof(Action<T, TParams>);
            var action = (Action<T, TParams>)method.CreateDelegate(deleType);

            return (n, c) =>
            {
                var notification = (NotificationMessage<TParams>)n;
                var target = provider.CreateTargetObject(targetType, c);
                try
                {
                    action((T)target, notification.@params);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private static MethodInfo GetFactoryForNotification2(MethodInfo method, Type delcaringType, Type paramsType)
        {
            return typeof(Reflector).GetTypeInfo().GetDeclaredMethod(nameof(ForNotification2)).MakeGenericMethod(delcaringType, paramsType);
        }

        private static NotificationHandlerDelegate ForNotification1<T>(Type targetType, MethodInfo method, HandlerProvider provider)
        {
            var deleType = typeof(Action<T>);
            var action = (Action<T>)method.CreateDelegate(deleType);

            return (n, c) =>
            {
                var notification = (VoidNotificationMessage)n;
                var target = provider.CreateTargetObject(targetType, c);
                try
                {
                    action((T)target);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private static MethodInfo GetFactoryForNotification1(MethodInfo method, Type declaringType)
        {
            return typeof(Reflector).GetTypeInfo().GetDeclaredMethod(nameof(ForNotification1)).MakeGenericMethod(declaringType);
        }

        internal static RequestHandlerDelegate CreateRequestHandlerDelegate(Type targetType, MethodInfo method, HandlerProvider provider)
        {
            var declaringType = method.DeclaringType;
            var parameters = method.GetParameters();
            if (parameters.Length > 1)
            {
                throw new ArgumentException($"signature mismatch: {method.Name}");
            }
            Type paramsType = (parameters.Length == 1) ? parameters[0].ParameterType : null;
            var returnType = method.ReturnType;
            var openReturnType = returnType.GetGenericTypeDefinition();
            Type resultType;
            Type responseErrorType;
            if (openReturnType == typeof(Result<,>))
            {
                resultType = returnType.GenericTypeArguments[0];
                responseErrorType = returnType.GenericTypeArguments[1];
            }
            else if (returnType.GetGenericTypeDefinition() == typeof(VoidResult<>))
            {
                resultType = null;
                responseErrorType = returnType.GenericTypeArguments[0];
            }
            else
            {
                throw new ArgumentException($"signature mismatch: {method.Name}");
            }
            var factory =
                (paramsType != null && resultType != null) ? GetFactoryForRequest4(method, declaringType, paramsType, resultType, responseErrorType) :
                (paramsType == null && resultType != null) ? GetFactoryForRequest3(method, declaringType, resultType, responseErrorType) :
                GetFactoryForRequest2(method, declaringType, responseErrorType);
            return (RequestHandlerDelegate)factory.Invoke(provider, new object[] { targetType, method, provider });
        }

        internal static NotificationHandlerDelegate CreateNotificationHandlerDelegate(Type targetType, MethodInfo method, HandlerProvider provider)
        {
            var declaringType = method.DeclaringType;
            var argTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
            if (argTypes.Length > 1)
            {
                throw new ArgumentException($"signature mismatch: {method.Name}");
            }
            if (method.ReturnType != typeof(void))
            {
                throw new ArgumentException($"signature mismatch: {method.Name}");
            }
            var factory = (argTypes.Length == 1)
                ? GetFactoryForNotification2(method, declaringType, argTypes[0])
                : GetFactoryForNotification1(method, declaringType);
            return (NotificationHandlerDelegate)factory.Invoke(provider, new object[] { targetType, method, provider });
        }

        internal static ResponseMessageBase CreateErrorResponse(Type responseType, string errorMessage)
        {
            var res = (ResponseMessageBase)Activator.CreateInstance(responseType);
            var prop = responseType.GetRuntimeProperty("error");
            var err = (ResponseError)Activator.CreateInstance(prop.PropertyType);
            err.code = ErrorCodes.InternalError;
            err.message = errorMessage;
            prop.SetValue(res, err);
            return res;
        }
    }
}
