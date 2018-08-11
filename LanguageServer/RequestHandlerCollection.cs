using System;
using System.Collections.Generic;
using System.Threading;

namespace LanguageServer
{
    public class RequestHandlerCollection
    {
        private readonly Dictionary<string, RequestHandler> dictionary = new Dictionary<string, RequestHandler>();

        public void Set<TRequest, TResponse>(string rpcMethod, Func<TRequest, CancellationToken, TResponse> handler)
            where TRequest : RequestMessageBase
            where TResponse : ResponseMessageBase
        {
            object Func(object request, Connection _, CancellationToken cancellationToken)
                => handler((TRequest) request, cancellationToken);
            var value = new RequestHandler(rpcMethod, typeof(TRequest), typeof(TResponse), Func);
            dictionary[rpcMethod] = value;
        }

        public void Set<TRequest, TResponse>(string rpcMethod, Func<TRequest, Connection, CancellationToken, TResponse> handler)
            where TRequest : RequestMessageBase
            where TResponse : ResponseMessageBase
        {
            object Func(object request, Connection connection, CancellationToken cancellationToken)
                => handler((TRequest) request, connection, cancellationToken);
            var value = new RequestHandler(rpcMethod, typeof(TRequest), typeof(TResponse), Func);
            dictionary[rpcMethod] = value;
        }

        public void Set(string rpcMethod, Type paramType, Type returnType, Func<object, CancellationToken, object> handler)
        {
            object Func(object request, Connection _, CancellationToken cancellationToken)
                => handler(request, cancellationToken);
            var value = new RequestHandler(rpcMethod, paramType, returnType, Func);
            dictionary[rpcMethod] = value;
        }
        
        public void Set(string rpcMethod, Type paramType, Type returnType, Func<object, Connection, CancellationToken, object> handler)
        {
            var cast = (RequestHandlerDelegate) ((Delegate) handler);
            var value = new RequestHandler(rpcMethod, paramType, returnType, cast);
            dictionary[rpcMethod] = value;
        }

        public void Clear() => dictionary.Clear();

        public int Count => dictionary.Count;

        public bool ContainsKey(string method) => dictionary.ContainsKey(method);

        public bool Remove(string method) => dictionary.Remove(method);

        public ICollection<string> Keys => dictionary.Keys;
        
        internal void AddRequestHandler(RequestHandler requestHandler)
        {
            dictionary[requestHandler.RpcMethod] = requestHandler;
        }

        internal void AddRequestHandlers(IEnumerable<RequestHandler> requestHandlers)
        {
            foreach(var handler in requestHandlers)
            {
                AddRequestHandler(handler);
            }
        }

        internal bool TryGetRequestHandler(string rpcMethod, out RequestHandler requestHandler)
        {
            return dictionary.TryGetValue(rpcMethod, out requestHandler);
        }
    }
}