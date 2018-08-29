using LanguageServer.Client;
using LanguageServer.Parameters;
using LanguageServer.Parameters.Workspace;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Server
{
    public class WorkspaceServiceTemplate : Service
    {
        private Proxy _proxy;

        public override Connection Connection
        {
            get => base.Connection;
            set
            {
                base.Connection = value;
                _proxy = new Proxy(value);
            }
        }

        public Proxy Proxy { get => _proxy; }

        /// <summary>
        /// The <c>workspace/didChangeWorkspaceFolders</c> notification is sent from the client
        /// to the server to inform the server about workspace folder configuration changes. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// The notification is sent by default if both <i>ServerCapabilities/workspace/workspaceFolders</i>
        /// and <i>ClientCapabilities/workspace/workspaceFolders</i> are true;
        /// or if the server has registered to receive this notification it first.
        /// </para>
        /// <para>
        /// To register for the <c>workspace/didChangeWorkspaceFolders</c>
        /// send a <c>client/registerCapability</c> request from the client to the server.
        /// The registration parameter must have a registrations item of the following form,
        /// where <c>id</c> is a unique id used to unregister the capability (the example uses a UUID):
        /// </para>
        /// <code><![CDATA[{
        ///     id: "28c6150c-bd7b-11e7-abc4-cec278b6b50a",
        ///     method: "workspace/didChangeWorkspaceFolders"
        /// }]]></code>
        /// </remarks>
        /// <param name="params"></param>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("workspace/didChangeWorkspaceFolders")]
        protected virtual void DidChangeWorkspaceFolders(DidChangeWorkspaceFoldersParams @params)
        {
        }

        // dynamicRegistration?: boolean;
        [JsonRpcMethod("workspace/didChangeConfiguration")]
        protected virtual void DidChangeConfiguration(DidChangeConfigurationParams @params)
        {
        }

        // dynamicRegistration?: boolean;
        [JsonRpcMethod("workspace/didChangeWatchedFiles")]
        protected virtual void DidChangeWatchedFiles(DidChangeWatchedFilesParams @params)
        {
        }

        // dynamicRegistration?: boolean;
        // Registration Options: void
        [JsonRpcMethod("workspace/symbol")]
        protected virtual Result<SymbolInformation[], ResponseError> Symbol(WorkspaceSymbolParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: ExecuteCommandRegistrationOptions
        [JsonRpcMethod("workspace/executeCommand")]
        protected virtual Result<dynamic, ResponseError> ExecuteCommand(ExecuteCommandParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
