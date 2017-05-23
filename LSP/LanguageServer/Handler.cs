using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LanguageServer
{
    internal class ResponseHandler
    {
        private readonly Type _responseType;
        private readonly Action<object> _handler;

        internal Type ResponseType { get => _responseType; }

        internal ResponseHandler(Type responseType, Action<object> handler)
        {
            this._responseType = responseType;
            this._handler = handler;
        }

        internal void Handle(object response)
        {
            _handler(response);
        }
    }

    internal class RequestHandler
    {
        private readonly Type _requestType;
        private readonly Type _responseType;
        private readonly Func<object, CancellationToken, object> _handler;

        internal Type RequestType { get => _requestType; }

        internal Type ResponseType { get => _responseType; }

        internal RequestHandler(Type requestType, Type responseType, Func<object, CancellationToken, object> handler)
        {
            this._requestType = requestType;
            this._responseType = responseType;
            this._handler = handler;
        }

        internal object Handle(object request, CancellationToken token)
        {
            return _handler(request, token);
        }
    }

    internal class NotificationHandler
    {
        private readonly Type _notificationType;
        private readonly Action<object> _handler;

        internal Type NotificationType { get => _notificationType; }

        internal NotificationHandler(Type notificationType, Action<object> handler)
        {
            this._notificationType = notificationType;
            this._handler = handler;
        }

        internal void Handle(object notification)
        {
            _handler(notification);
        }
    }
}
