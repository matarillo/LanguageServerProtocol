using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentHighlight
    {
        public Range range { get; set; }

        public DocumentHighlightKind? kind { get; set; }
    }
}
