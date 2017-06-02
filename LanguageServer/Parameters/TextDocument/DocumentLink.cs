using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class DocumentLink
    {
        public Range range { get; set; }

        public Uri target { get; set; }
    }
}
