using LanguageServer.Json;

namespace LanguageServer
{
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

    public abstract class Message
    {
        public string jsonrpc { get; set; } = "2.0";
    }

    public abstract class MethodCall : Message
    {
        public string method { get; set; }
    }

    public abstract class ResponseMessageBase : Message
    {
        public NumberOrString id { get; set; }
    }

    public class RequestMessage : MethodCall
    {
        public NumberOrString id { get; set; }
    }

    public class RequestMessage<T> : RequestMessage
    {
        public T @params { get; set; }
    }

    public class ResponseMessage<T, TErrorData> : ResponseMessageBase
    {
        public T result { get; set; }

        public Error<TErrorData> error { get; set; }
    }

    public class _ResponseMessage : ResponseMessageBase
    {
        public ResponseError error { get; set; }
    }

    public class _ResponseMessage<T> : ResponseMessageBase
    {
        public T result { get; set; }

        public ResponseError error { get; set; }
    }

    public class _ResponseMessage<T, TError> : ResponseMessageBase
        where TError : ResponseError
    {
        public T result { get; set; }

        public TError error { get; set; }
    }

    public class NotificationMessage : MethodCall
    {
    }

    public class NotificationMessage<T> : NotificationMessage
    {
        public T @params { get; set; }
    }

    public class ResponseError
    {
        public ErrorCodes code { get; set; }

        public string message { get; set; }
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
