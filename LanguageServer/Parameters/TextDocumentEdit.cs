using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    public class TextDocumentEdit
    {
        public VersionedTextDocumentIdentifier textDocument { get; set; }

        public TextEdit[] edits { get; set; }
    }
}
