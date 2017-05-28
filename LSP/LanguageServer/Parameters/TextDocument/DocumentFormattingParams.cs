using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentFormattingParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public FormattingOptions options { get; set; }
    }
}
