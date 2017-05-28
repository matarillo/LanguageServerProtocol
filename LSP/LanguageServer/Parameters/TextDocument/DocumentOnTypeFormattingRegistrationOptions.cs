using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentOnTypeFormattingRegistrationOptions : TextDocumentRegistrationOptions
    {
        public string firstTriggerCharacter { get; set; }

        public string[] moreTriggerCharacter { get; set; }
    }
}
