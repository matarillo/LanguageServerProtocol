using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    public class WorkspaceEdit
    {
        public Dictionary<Uri, TextEdit[]> changes { get; set; }

        public TextDocumentEdit[] documentChanges { get; set; }
    }
}
