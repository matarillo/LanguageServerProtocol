using System;
using System.Collections.Generic;

namespace LanguageServer
{
    public class NotificationHandlerCollection
    {
        private readonly Dictionary<string, NotificationHandler> dictionary = new Dictionary<string, NotificationHandler>();
        
        public void Set<TRequest>(string rpcMethod, Action<TRequest> handler)
            where TRequest : RequestMessageBase
        {
            void Action(object request, Connection _) => handler((TRequest) request);
            var value = new NotificationHandler(rpcMethod, typeof(TRequest), Action);
            dictionary[rpcMethod] = value;
        }

        public void Set<TRequest>(string rpcMethod, Action<TRequest, Connection> handler)
            where TRequest : RequestMessageBase
        {
            void Action(object request, Connection connection) => handler((TRequest) request, connection);
            var value = new NotificationHandler(rpcMethod, typeof(TRequest), Action);
            dictionary[rpcMethod] = value;
        }

        public void Set(string rpcMethod, Type paramType, Action<object> handler)
        {
            void Action(object request, Connection _) => handler(request);
            var value = new NotificationHandler(rpcMethod, paramType, Action);
            dictionary[rpcMethod] = value;
        }

        public void Set(string rpcMethod, Type paramType, Action<object, Connection> handler)
        {
            var cast = (NotificationHandlerDelegate) ((Delegate) handler);
            var value = new NotificationHandler(rpcMethod, paramType, cast);
            dictionary[rpcMethod] = value;
        }

        public void Clear() => dictionary.Clear();

        public int Count => dictionary.Count;

        public bool ContainsKey(string method) => dictionary.ContainsKey(method);

        public bool Remove(string method) => dictionary.Remove(method);

        public ICollection<string> Keys => dictionary.Keys;

        internal void AddNotificationHandler(NotificationHandler notificationHandler)
        {
            dictionary[notificationHandler.RpcMethod] = notificationHandler;
        }

        internal void AddNotificationHandlers(IEnumerable<NotificationHandler> notificationHandlers)
        {
            foreach(var handler in notificationHandlers)
            {
                AddNotificationHandler(handler);
            }
        }

        internal bool TryGetNotificationHandler(string rpcMethod, out NotificationHandler notificationHandler)
        {
            return dictionary.TryGetValue(rpcMethod, out notificationHandler);
        }
    }
}