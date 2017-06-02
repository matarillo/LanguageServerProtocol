using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class FormattingOptions
    {
        public int tabSize { get; set; }

        public bool insertSpaces { get; set; }

        // Signature for further properties.
        // [key: string]: boolean | number | string;
    }
}
