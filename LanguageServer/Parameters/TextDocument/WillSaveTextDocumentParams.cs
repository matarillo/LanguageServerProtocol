using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/willSave</c>
    /// </summary>
    public class WillSaveTextDocumentParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public TextDocumentSaveReason reason { get; set; }
    }
}
