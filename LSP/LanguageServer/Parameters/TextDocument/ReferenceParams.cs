using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class ReferenceParams : TextDocumentPositionParams
    {
        public ReferenceContext context { get; set; }
    }
}
