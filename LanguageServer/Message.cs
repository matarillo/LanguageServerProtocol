using LanguageServer.Json;
using System;

namespace LanguageServer
{
    public static class Message
    {
        public static Result<T, TError> ToResult<T, TError>(ResponseMessage<T, TError> response)
            where TError : ResponseError
        {
            return (response.error == null)
                ? Result<T, TError>.Success(response.result)
                : Result<T, TError>.Error(response.error);
        }

        public static VoidResult<TError> ToResult<TError>(VoidResponseMessage<TError> response)
            where TError : ResponseError
        {
            return (response.error == null)
                ? VoidResult<TError>.Success()
                : VoidResult<TError>.Error(response.error);
        }

        public static ResponseError ParseError() => new ResponseError { code = ErrorCodes.ParseError, message = "Parse error" };
        public static ResponseError<T> ParseError<T>(T data) => new ResponseError<T> { code = ErrorCodes.ParseError, message = "Parse error", data = data };

        public static ResponseError InvalidRequest() => new ResponseError { code = ErrorCodes.InvalidRequest, message = "Invalid Request" };
        public static ResponseError<T> InvalidRequest<T>(T data) => new ResponseError<T> { code = ErrorCodes.InvalidRequest, message = "Invalid Request", data = data };

        public static ResponseError MethodNotFound() => new ResponseError { code = ErrorCodes.MethodNotFound, message = "Method not found" };
        public static ResponseError<T> MethodNotFound<T>(T data) => new ResponseError<T> { code = ErrorCodes.MethodNotFound, message = "Method not found", data = data };

        public static ResponseError InvalidParams() => new ResponseError { code = ErrorCodes.InvalidParams, message = "Invalid params" };
        public static ResponseError<T> InvalidParams<T>(T data) => new ResponseError<T> { code = ErrorCodes.InvalidParams, message = "Invalid params", data = data };

        public static TResponseError InternalError<TResponseError>() where TResponseError : ResponseError, new() => new TResponseError { code = ErrorCodes.InternalError, message = "Internal error" };
        public static ResponseError InternalError() => new ResponseError { code = ErrorCodes.InternalError, message = "Internal error" };
        public static ResponseError<T> InternalError<T>(T data) => new ResponseError<T> { code = ErrorCodes.InternalError, message = "Internal error", data = data };

        public static ResponseError ServerError(ErrorCodes code) => new ResponseError { code = code, message = "Server error" };
        public static ResponseError<T> ServerError<T>(ErrorCodes code, T data) => new ResponseError<T> { code = code, message = "Server error", data = data };
    }

    internal class MessageTest
    {
        public string jsonrpc { get; set; }

        public NumberOrString id { get; set; }

        public string method { get; set; }

        public bool IsMessage
        {
            get => jsonrpc == "2.0";
        }

        public bool IsRequest
        {
            get => (IsMessage && id != null && method != null);
        }

        public bool IsResponse
        {
            get => (IsMessage && id != null && method == null);
        }

        public bool IsNotification
        {
            get => (IsMessage && id == null && method != null);
        }

        public bool IsCancellation
        {
            get => (IsNotification && method == "$/cancelRequest");
        }
    }

    public abstract class MessageBase
    {
        public string jsonrpc { get; set; } = "2.0";
    }

    public abstract class MethodCall : MessageBase
    {
        public string method { get; set; }
    }

    public abstract class RequestMessageBase : MethodCall
    {
        public NumberOrString id { get; set; }
    }

    public class VoidRequestMessage : RequestMessageBase
    {
    }

    public class RequestMessage<T> : RequestMessageBase
    {
        public T @params { get; set; }
    }

    public abstract class ResponseMessageBase : MessageBase
    {
        public NumberOrString id { get; set; }
    }

    public class VoidResponseMessage<TError> : ResponseMessageBase
        where TError : ResponseError
    {
        public TError error { get; set; }
    }

    public class ResponseMessage<T, TError> : ResponseMessageBase
        where TError : ResponseError
    {
        public T result { get; set; }

        public TError error { get; set; }
    }

    public abstract class NotificationMessageBase : MethodCall
    {
    }

    public class VoidNotificationMessage : NotificationMessageBase
    {
    }

    public class NotificationMessage<T> : NotificationMessageBase
    {
        public T @params { get; set; }
    }

    public class ResponseError
    {
        public ErrorCodes code { get; set; }

        public string message { get; set; }
    }

    public class ResponseError<T> : ResponseError
    {
        public T data { get; set; }
    }

    public enum ErrorCodes
    {
        ParseError = -32700,
        InvalidRequest = -32600,
        MethodNotFound = -32601,
        InvalidParams = -32602,
        InternalError = -32603,
        ServerErrorStart = -32099,
        ServerErrorEnd = -32000,
        ServerNotInitialized = -32002,
        UnknownErrorCode = -32001,
        RequestCancelled = -32800,
    }
}
