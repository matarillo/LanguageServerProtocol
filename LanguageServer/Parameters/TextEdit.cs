using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    public class TextEdit
    {
        public Range range { get; set; }

        public string newText { get; set; }
    }
}
