using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class PublishDiagnosticsParams
    {
        public Uri uri { get; set; }

        public Diagnostic[] diagnostics { get; set; }
    }
}
