using LanguageServer.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class Hover
    {
        /// <summary>
        /// The hover's content
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public HoverContents contents { get; set; }

        public Range range { get; set; }
    }
}
