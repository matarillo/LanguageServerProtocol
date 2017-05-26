using LanguageServer.Parameters.TextDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Client
{
    public class TextDocumentProxy
    {
        private readonly Connection _connection;

        internal TextDocumentProxy(Connection connection)
        {
            _connection = connection;
        }

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
