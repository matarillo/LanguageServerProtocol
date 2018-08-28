using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/rename</c> and <c>workspace/applyEdit</c>
    /// </summary>
    public class TextDocumentEdit
    {
        public VersionedTextDocumentIdentifier textDocument { get; set; }

        public TextEdit[] edits { get; set; }
    }
}
