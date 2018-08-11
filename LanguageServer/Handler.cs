using LanguageServer.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LanguageServer
{
    internal class ResponseHandler
    {
        private NumberOrString _id;
        private readonly Type _responseType;
        private readonly ResponseHandlerDelegate _handler;

        internal NumberOrString Id => _id;
        internal Type ResponseType => _responseType;

        internal ResponseHandler(NumberOrString id, Type responseType, ResponseHandlerDelegate handler)
        {
            _id = id;
            _responseType = responseType;
            _handler = handler;
        }

        internal void Handle(object response)
        {
            _handler(response);
        }
    }

    internal delegate void ResponseHandlerDelegate(object response);

    internal class RequestHandler
    {
        private readonly string _rpcMethod;
        private readonly Type _requestType;
        private readonly Type _responseType;
        private readonly RequestHandlerDelegate _handler;

        internal string RpcMethod => _rpcMethod;
        internal Type RequestType => _requestType;
        internal Type ResponseType => _responseType;

        internal RequestHandler(string rpcMethod, Type requestType, Type responseType, RequestHandlerDelegate handler)
        {
            _rpcMethod = rpcMethod;
            _requestType = requestType;
            _responseType = responseType;
            _handler = handler;
        }

        internal object Handle(object request, Connection connection, CancellationToken token)
        {
            return _handler(request, connection, token);
        }
    }

    internal delegate object RequestHandlerDelegate(object request, Connection connection, CancellationToken token);

    internal class NotificationHandler
    {
        private readonly string _rpcMethod;
        private readonly Type _notificationType;
        private readonly NotificationHandlerDelegate _handler;

        internal string RpcMethod => _rpcMethod;
        internal Type NotificationType => _notificationType;

        internal NotificationHandler(string rpcMethod, Type notificationType, NotificationHandlerDelegate handler)
        {
            _rpcMethod = rpcMethod;
            _notificationType = notificationType;
            _handler = handler;
        }

        internal void Handle(object notification, Connection connection)
        {
            _handler(notification, connection);
        }
    }

    internal delegate void NotificationHandlerDelegate(object notification, Connection connection);
}
