using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    // initialize & textDocument/didChange
    public enum TextDocumentSyncKind
    {
        None = 0,
        Full = 1,
        Incremental = 2,
    }
}
