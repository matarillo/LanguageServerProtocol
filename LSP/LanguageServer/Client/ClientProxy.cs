using LanguageServer.Parameters;
using LanguageServer.Parameters.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Client
{
    public sealed class ClientProxy
    {
        private readonly Connection _connection;

        internal ClientProxy(Connection connection)
        {
            _connection = connection;
        }

        public Task<VoidResult<ResponseError>> RegisterCapability(RegistrationParams @params)
        {
            var tcs = new TaskCompletionSource<VoidResult<ResponseError>>();
            _connection.SendRequest(
                new RequestMessage<RegistrationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "client/registerCapability",
                    @params = @params
                },
                (VoidResponseMessage res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }

        public Task<VoidResult<ResponseError>> UnregisterCapability(UnregistrationParams @params)
        {
            var tcs = new TaskCompletionSource<VoidResult<ResponseError>>();
            _connection.SendRequest(
                new RequestMessage<UnregistrationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "client/unregisterCapability",
                    @params = @params
                },
                (VoidResponseMessage res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }
    }
}
