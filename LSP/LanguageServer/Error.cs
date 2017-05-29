using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer
{
    public static class Error
    {
        public static ResponseError ParseError() => new ResponseError { code = ErrorCodes.ParseError, message = "Parse error" };
        public static ResponseError<T> ParseError<T>(T data) => new ResponseError<T> { code = ErrorCodes.ParseError, message = "Parse error", data = data };

        public static ResponseError InvalidRequest() => new ResponseError { code = ErrorCodes.InvalidRequest, message = "Invalid Request" };
        public static ResponseError<T> InvalidRequest<T>(T data) => new ResponseError<T> { code = ErrorCodes.InvalidRequest, message = "Invalid Request", data = data };

        public static ResponseError MethodNotFound() => new ResponseError { code = ErrorCodes.MethodNotFound, message = "Method not found" };
        public static ResponseError<T> MethodNotFound<T>(T data) => new ResponseError<T> { code = ErrorCodes.MethodNotFound, message = "Method not found", data = data };

        public static ResponseError InvalidParams() => new ResponseError { code = ErrorCodes.InvalidParams, message = "Invalid params" };
        public static ResponseError<T> InvalidParams<T>(T data) => new ResponseError<T> { code = ErrorCodes.InvalidParams, message = "Invalid params", data = data };

        public static ResponseError InternalError() => new ResponseError { code = ErrorCodes.InternalError, message = "Internal error" };
        public static ResponseError<T> InternalError<T>(T data) => new ResponseError<T> { code = ErrorCodes.InternalError, message = "Internal error", data = data };

        public static ResponseError ServerError(ErrorCodes code) => new ResponseError { code = code, message = "Server error" };
        public static ResponseError<T> ServerError<T>(ErrorCodes code, T data) => new ResponseError<T> { code = code, message = "Server error", data = data };
    }
}
