using LanguageServer.Parameters;
using LanguageServer.Parameters.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Client
{
    public sealed class WindowProxy
    {
        private readonly Connection _connection;

        internal WindowProxy(Connection connection)
        {
            _connection = connection;
        }

        public void ShowMessage(ShowMessageParams @params)
        {
            _connection.SendNotification(new NotificationMessage<ShowMessageParams>
            {
                method = "window/showMessage",
                @params = @params
            });
        }

        public Task<Result<MessageActionItem, Error<_Void>>> ShowMessageRequest(ShowMessageRequestParams @params)
        {
            var tcs = new TaskCompletionSource<Result<MessageActionItem, Error<_Void>>>();
            _connection.SendRequest<ShowMessageRequestParams, MessageActionItem, _Void>(
                new RequestMessage<ShowMessageRequestParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "window/showMessageRequest",
                    @params = @params
                },
                res => tcs.TrySetResult(new Result<MessageActionItem, Error<_Void>>(res.result, res.error)));
            return tcs.Task;
        }

        public void LogMessage(LogMessageParams @params)
        {
            _connection.SendNotification(new NotificationMessage<LogMessageParams>
            {
                method = "window/logMessage",
                @params = @params
            });
        }

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
