using System;
using System.Collections.Generic;
using System.Text;
using LanguageServer.Parameters.General;

namespace LanguageServer.Parameters.Client
{
    /// <summary>
    /// For <c>client/registerCapability</c>
    /// </summary>
    public class TextDocumentChangeRegistrationOptions : TextDocumentRegistrationOptions
    {
        public TextDocumentSyncKind syncKind { get; set; }
    }
}
