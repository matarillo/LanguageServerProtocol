using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DidSaveTextDocumentParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public string text { get; set; }
    }
}
