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

        /// <summary>
        /// The <c>workspace/workspaceFolders</c> request is sent from the server to the client
        /// to fetch the current open list of workspace folders. 
        /// </summary>
        /// <returns>
        /// Returns <c>null</c> in the response if only a single file is open in the tool.
        /// Returns an empty array if a workspace is open but no folders are configured.
        /// </returns>
        /// <seealso>Spec 3.6.0</seealso>
        public Task<Result<WorkspaceFolder[], ResponseError>> WorkspaceFolders()
        {
            var tcs = new TaskCompletionSource<Result<WorkspaceFolder[], ResponseError>>();
            _connection.SendRequest(
                new VoidRequestMessage
                {
                    id = IdGenerator.Instance.Next(),
                    method = "workspace/workspaceFolders"
                },
                (ResponseMessage<WorkspaceFolder[], ResponseError> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }

        /// <summary>
        /// The <c>workspace/configuration</c> request is sent from the server to the client
        /// to fetch configuration settings from the client.
        /// The request can fetch n configuration settings in one roundtrip. 
        /// </summary>
        /// <param name="params">configuration sections asked for</param>
        /// <returns>configuration settings</returns>
        /// <seealso>Spec 3.6.0</seealso>
        public Task<Result<dynamic[], ResponseError>> Configuration(ConfigurationParams @params)
        {
            var tcs = new TaskCompletionSource<Result<dynamic[], ResponseError>>();
            _connection.SendRequest(
                new RequestMessage<ConfigurationParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "workspace/configuration",
                    @params = @params
                },
                (ResponseMessage<dynamic[], ResponseError> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }
    }
}
