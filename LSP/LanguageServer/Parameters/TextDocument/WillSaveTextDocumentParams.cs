using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class WillSaveTextDocumentParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public TextDocumentSaveReason reason { get; set; }
    }
}
