using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>workspace/symbol</c>,
    /// <c>textDocument/documentSymbol</c>,
    /// <c>textDocument/references</c>,
    /// <c>textDocument/definition</c>, and
    /// <c>workspace/symbol</c>
    /// </summary>
    public class Location
    {
        public Uri uri { get; set; }
        public Range range { get; set; }
    }
}
