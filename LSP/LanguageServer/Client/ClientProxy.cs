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

        public Task<Result<_Void, ResponseError>> RegisterCapability(RegistrationParams @params)
        {
            var tcs = new TaskCompletionSource<Result<_Void, ResponseError>>();
            _connection.SendRequest<RegistrationParams, _Void, ResponseError>(
                new RequestMessage<RegistrationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "client/registerCapability",
                    @params = @params
                },
                res => tcs.TrySetResult(new Result<_Void, ResponseError>(res.result, res.error)));
            return tcs.Task;
        }

        public Task<Result<_Void, ResponseError>> UnregisterCapability(UnregistrationParams @params)
        {
            var tcs = new TaskCompletionSource<Result<_Void, ResponseError>>();
            _connection.SendRequest<UnregistrationParams, _Void, ResponseError>(
                new RequestMessage<UnregistrationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "client/unregisterCapability",
                    @params = @params
                },
                res => tcs.TrySetResult(new Result<_Void, ResponseError>(res.result, res.error)));
            return tcs.Task;
        }
    }
}
