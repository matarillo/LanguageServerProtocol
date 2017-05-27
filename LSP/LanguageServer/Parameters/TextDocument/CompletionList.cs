using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class CompletionList
    {
        public bool isIncomplete { get; set; }

        public CompletionItem[] items { get; set; }
    }
}
