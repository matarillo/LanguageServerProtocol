using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class SignatureHelpRegistrationOptions : TextDocumentRegistrationOptions
    {
        public string[] triggerCharacters { get; set; }
    }
}
