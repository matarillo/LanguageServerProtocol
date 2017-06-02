using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class CompletionRegistrationOptions : TextDocumentRegistrationOptions
    {
        public string[] triggerCharacters { get; set; }

        public bool? resolveProvider { get; set; }
    }
}
