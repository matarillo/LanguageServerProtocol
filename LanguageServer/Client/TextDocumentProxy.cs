using LanguageServer.Parameters.TextDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Client
{
    /// <summary>
    /// The proxy class for sending messages related to <c>textDocument</c>.
    /// </summary>
    public class TextDocumentProxy
    {
        private readonly Connection _connection;

        internal TextDocumentProxy(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// The <c>textDocument/publishDiagnostics</c> notification is sent from the server to the client
        /// to signal results of validation runs.
        /// </summary>
        /// <param name="params"></param>
        public void PublishDiagnostics(PublishDiagnosticsParams @params)
        {
            _connection.SendNotification(new NotificationMessage<PublishDiagnosticsParams>
            {
                method = "textDocument/publishDiagnostics",
                @params = @params
            });
        }
    }
}
