using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    /// <seealso>Spec 3.3.0</seealso>
    public class CompletionParams : TextDocumentPositionParams
    {
        /// <summary>
        /// The completion context.
        /// </summary>
        /// <remarks>
        /// This is only available if the client specifies to send this
        /// using <c>ClientCapabilities.textDocument.completion.contextSupport === true</c>
        /// </remarks>/remarks>
        /// <seealso>Spec 3.3.0</seealso>
        public CompletionContext context { get; set; }
    }
}
