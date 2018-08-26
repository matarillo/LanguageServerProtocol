using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Client
{
    /// <summary>
    /// For <c>initialize</c> and <c>client/registerCapability</c>
    /// </summary>
    public class TextDocumentRegistrationOptions : RegistrationOptions
    {
        public DocumentFilter[] documentSelector { get; set; }
    }
}
