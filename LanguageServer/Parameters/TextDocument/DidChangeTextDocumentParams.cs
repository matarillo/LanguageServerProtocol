using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/didChange</c>
    /// </summary>
    public class DidChangeTextDocumentParams
    {
        public VersionedTextDocumentIdentifier textDocument { get; set; }

        public TextDocumentContentChangeEvent[] contentChanges { get; set; }
    }
}
