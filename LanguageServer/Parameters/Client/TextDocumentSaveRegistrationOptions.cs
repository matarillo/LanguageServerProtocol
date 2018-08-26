using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Client
{
    /// <summary>
    /// For <c>client/registerCapability</c>
    /// </summary>
    public class TextDocumentSaveRegistrationOptions : TextDocumentRegistrationOptions
    {
        public bool? includeText { get; set; }
    }
}
