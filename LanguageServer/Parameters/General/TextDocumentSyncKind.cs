using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c> and <c>textDocument/didChange</c>
    /// </summary>
    public enum TextDocumentSyncKind
    {
        None = 0,
        Full = 1,
        Incremental = 2,
    }
}
