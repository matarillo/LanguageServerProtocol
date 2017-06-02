using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    public class TextDocumentRegistrationOptions
    {
        public DocumentFilter[] documentSelector { get; set; }
    }
}
