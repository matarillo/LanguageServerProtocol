using LanguageServer.Parameters.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Client
{
    /// <summary>
    /// The proxy class for sending messages related to <c>client</c>.
    /// </summary>
    public sealed class ClientProxy
    {
        private readonly Connection _connection;

        internal ClientProxy(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// The <c>client/registerCapability</c> request is sent from the server to the client
        /// to register for a new capability on the client side.
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
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
                (VoidResponseMessage<ResponseError> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }

        /// <summary>
        /// The <c>client/unregisterCapability</c> request is sent from the server to the client
        /// to unregister a previously registered capability.
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
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
                (VoidResponseMessage<ResponseError> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }
    }
}
