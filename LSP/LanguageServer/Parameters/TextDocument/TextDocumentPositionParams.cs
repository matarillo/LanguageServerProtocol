using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class TextDocumentPositionParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public Position position { get; set; }
    }
}
