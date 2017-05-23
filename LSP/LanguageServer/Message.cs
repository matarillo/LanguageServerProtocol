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

    public abstract class ResponseMessage : Message
    {
        public NumberOrString id { get; set; }
    }

    public class RequestMessage<T> : MethodCall
    {
        public T @params { get; set; }

        public NumberOrString id { get; set; }
    }

    public class ResponseMessage<T, TErrorData> : ResponseMessage
    {
        public T result { get; set; }

        public Error<TErrorData> error { get; set; }
    }

    public class NotificationMessage<T> : MethodCall
    {
        public T @params { get; set; }
    }
}
