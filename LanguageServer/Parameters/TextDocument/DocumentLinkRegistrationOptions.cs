using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentLinkRegistrationOptions : TextDocumentRegistrationOptions
    {
        public bool? resolveProvider { get; set; }
    }
}
