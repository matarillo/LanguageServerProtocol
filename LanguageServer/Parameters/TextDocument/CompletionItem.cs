using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class CompletionItem
    {
        public string label { get; set; }

        public CompletionItemKind? kind { get; set; }

        public string detail { get; set; }

        public string documentation { get; set; }

        public string sortText { get; set; }

        public string filterText { get; set; }

        public string insertText { get; set; }

        public InsertTextFormat? insertTextFormat { get; set; }

        public TextEdit textEdit { get; set; }

        public TextEdit[] additionalTextEdits { get; set; }

        public Command command { get; set; }

        public dynamic data { get; set; }
    }
}
