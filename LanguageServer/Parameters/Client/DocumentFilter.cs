using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Client
{
    /// <summary>
    /// For <c>client/registerCapability</c>
    /// </summary>
    public class DocumentFilter
    {
        public string language { get; set; }

        public string scheme { get; set; }

        public string pattern { get; set; }
    }
}
