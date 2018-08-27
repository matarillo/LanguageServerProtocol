using LanguageServer.Parameters.Client;
using LanguageServer.Parameters.Workspace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Client
{
    /// <summary>
    /// The proxy class for sending messages related to <c>workspace</c>.
    /// </summary>
    public class WorkspaceProxy
    {
        private readonly Connection _connection;

        internal WorkspaceProxy(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// The <c>workspace/applyEdit</c> request is sent from the server to the client
        /// to modify resource on the client side.
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public Task<Result<ApplyWorkspaceEditResponse, ResponseError>> ApplyEdit(ApplyWorkspaceEditParams @params)
        {
            var tcs = new TaskCompletionSource<Result<ApplyWorkspaceEditResponse, ResponseError>>();
            _connection.SendRequest(
                new RequestMessage<ApplyWorkspaceEditParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "workspace/applyEdit",
                    @params = @params
                },
                (ResponseMessage<ApplyWorkspaceEditResponse, ResponseError> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }
    }
}
