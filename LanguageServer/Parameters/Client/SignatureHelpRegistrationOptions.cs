using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Client
{
    /// <summary>
    /// For <c>client/registerCapability</c>
    /// </summary>
    public class SignatureHelpRegistrationOptions : TextDocumentRegistrationOptions
    {
        public string[] triggerCharacters { get; set; }
    }
}
