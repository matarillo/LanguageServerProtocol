using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/willSaveWaitUntil</c>,
    /// <c>textDocument/completion</c>,
    /// <c>textDocument/formatting</c>,
    /// <c>textDocument/rangeFormatting</c>,
    /// <c>textDocument/onTypeFormatting</c>,
    /// <c>textDocument/rename</c>, and
    /// <c>workspace/applyEdit</c>
    /// </summary>
    public class TextEdit
    {
        public Range range { get; set; }

        public string newText { get; set; }
    }
}
