using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentRangeFormattingParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public Range range { get; set; }

        public FormattingOptions options { get; set; }
    }
}
