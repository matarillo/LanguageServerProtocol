using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class CodeLens
    {
        public Range range { get; set; }

        public Command command { get; set; }

        public dynamic any { get; set; }
    }
}
