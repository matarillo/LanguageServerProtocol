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

        public Task<Result<_Void, Error<_Void>>> RegisterCapability(RegistrationParams @params)
        {
            var tcs = new TaskCompletionSource<Result<_Void, Error<_Void>>>();
            _connection.SendRequest<RegistrationParams, _Void, _Void>(
                new RequestMessage<RegistrationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "client/registerCapability",
                    @params = @params
                },
                res => tcs.TrySetResult(new Result<_Void, Error<_Void>>(res.result, res.error)));
            return tcs.Task;
        }


        public Task<Result<_Void, Error<_Void>>> UnregisterCapability(UnregistrationParams @params)
        {
            var tcs = new TaskCompletionSource<Result<_Void, Error<_Void>>>();
            _connection.SendRequest<UnregistrationParams, _Void, _Void>(
                new RequestMessage<UnregistrationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "client/unregisterCapability",
                    @params = @params
                },
                res => tcs.TrySetResult(new Result<_Void, Error<_Void>>(res.result, res.error)));
            return tcs.Task;
        }
    }
}
