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

    public class VoidRequestMessage : MethodCall
    {
        public NumberOrString id { get; set; }
    }

    public class RequestMessage<T> : VoidRequestMessage
    {
        public T @params { get; set; }
    }

    public class VoidResponseMessage : ResponseMessageBase
    {
        public ResponseError error { get; set; }
    }

    public class VoidResponseMessage<TError> : ResponseMessageBase
        where TError : ResponseError
    {
        public TError error { get; set; }
    }

    public class ResponseMessage<T> : ResponseMessageBase
    {
        public T result { get; set; }

        public ResponseError error { get; set; }
    }

    public class ResponseMessage<T, TError> : ResponseMessageBase
        where TError : ResponseError
    {
        public T result { get; set; }

        public TError error { get; set; }
    }

    public class VoidNotificationMessage : MethodCall
    {
    }

    public class NotificationMessage<T> : VoidNotificationMessage
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
