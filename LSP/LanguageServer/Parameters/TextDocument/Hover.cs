using LanguageServer.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class Hover
    {
        public ArrayOrObject<StringOrObject<MarkedString>, StringOrObject<MarkedString>> contents { get; set; }

        public Range range { get; set; }
    }
}
