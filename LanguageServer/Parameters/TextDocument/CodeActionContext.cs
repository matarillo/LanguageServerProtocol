using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class CodeActionContext
    {
        public Diagnostic[] diagnostics { get; set; }
    }
}
