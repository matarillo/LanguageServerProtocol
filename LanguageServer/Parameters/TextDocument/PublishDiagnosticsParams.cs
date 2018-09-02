using System;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/publishDiagnostics</c>
    /// </summary>
    public class PublishDiagnosticsParams
    {
        /// <summary>
        /// The URI for which diagnostic information is reported.
        /// </summary>
        public Uri uri { get; set; }

        /// <summary>
        /// An array of diagnostic information items.
        /// </summary>
        public Diagnostic[] diagnostics { get; set; }
    }
}
