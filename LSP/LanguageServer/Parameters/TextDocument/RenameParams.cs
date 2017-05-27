using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class RenameParams
    {
        public TextDocumentIdentifier textDocument { get; set; }

        public Position position { get; set; }

        public string newName { get; set; }
    }
}
