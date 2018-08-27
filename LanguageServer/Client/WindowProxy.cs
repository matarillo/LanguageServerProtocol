using LanguageServer.Parameters.Client;
using LanguageServer.Parameters.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Client
{
    /// <summary>
    /// The proxy class for sending messages related to <c>window</c>.
    /// </summary>
    public sealed class WindowProxy
    {
        private readonly Connection _connection;

        internal WindowProxy(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// The <c>window/showMessage</c> notification is sent from the server to the client
        /// to ask the client to display a particular message in the user interface.
        /// </summary>
        /// <param name="params"></param>
        public void ShowMessage(ShowMessageParams @params)
        {
            _connection.SendNotification(new NotificationMessage<ShowMessageParams>
            {
                method = "window/showMessage",
                @params = @params
            });
        }

        /// <summary>
        /// The <c>window/showMessageRequest</c> request is sent from the server to the client
        /// to ask the client to display a particular message in the user interface.
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public Task<Result<MessageActionItem, ResponseError>> ShowMessageRequest(ShowMessageRequestParams @params)
        {
            var tcs = new TaskCompletionSource<Result<MessageActionItem, ResponseError>>();
            _connection.SendRequest(
                new RequestMessage<ShowMessageRequestParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "window/showMessageRequest",
                    @params = @params
                },
                (ResponseMessage<MessageActionItem, ResponseError> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }

        /// <summary>
        /// The <c>window/logMessage</c> notification is sent from the server to the client
        /// to ask the client to log a particular message.
        /// </summary>
        /// <param name="params"></param>
        public void LogMessage(LogMessageParams @params)
        {
            _connection.SendNotification(new NotificationMessage<LogMessageParams>
            {
                method = "window/logMessage",
                @params = @params
            });
        }

        /// <summary>
        /// The <c>telemetry/event</c> notification is sent from the server to the client
        /// to ask the client to log a telemetry event.
        /// </summary>
        /// <param name="params"></param>
        public void Event(dynamic @params)
        {
            _connection.SendNotification(new NotificationMessage<dynamic>
            {
                method = "telemetry/event",
                @params = @params
            });
        }
    }
}
