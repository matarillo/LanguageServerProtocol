using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer
{
    public static class Error
    {
        public static Error<T> ParseError<T>(T data = null) where T : class => new Error<T> { code = -32700L, message = "Parse error", data = data };
        public static Error<T> InvalidRequest<T>(T data = null) where T : class => new Error<T> { code = -32600L, message = "Invalid Request", data = data };
        public static Error<T> MethodNotFound<T>(T data = null) where T : class => new Error<T> { code = -32601L, message = "Method not found", data = data };
        public static Error<T> InvalidParams<T>(T data = null) where T : class => new Error<T> { code = -32602L, message = "Invalid params", data = data };
        public static Error<T> InternalError<T>(T data = null) where T : class => new Error<T> { code = -32603L, message = "Internal error", data = data };
        public static Error<T> ServerError<T>(long code, T data = null) where T : class =>
            (-32000L >= code && code >= -32099L)
                ? new Error<T> { code = code, message = "Server error", data = data }
                : throw new ArgumentOutOfRangeException(nameof(code));
    }

    public sealed class Error<T>
    {
        public long code { get; set; }

        public string message { get; set; }

        public T data { get; set; }
    }
}
