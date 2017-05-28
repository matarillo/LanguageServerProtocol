using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class CodeActionParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public Range range { get; set; }

        public CodeActionContext context { get; set; }
    }
}
