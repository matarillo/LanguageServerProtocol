namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Represents a related message and source code location for a diagnostic.
    /// For <c>textDocument/codeAction</c> and <c>textDocument/publishDiagnostics</c>
    /// </summary>
    /// <remarks>
    /// This should be used to point to code locations that cause or related to a diagnostics,
    /// e.g when duplicating a symbol in a scope.
    /// </remarks>
    /// <seealso>Spec 3.7.0</seealso>
    public class DiagnosticRelatedInformation
    {
        /// <summary>
        /// The location of this related diagnostic information.
        /// </summary>
        /// <seealso>Spec 3.7.0</seealso>
        public Location location { get; set; }

        /// <summary>
        /// The message of this related diagnostic information.
        /// </summary>
        /// <seealso>Spec 3.7.0</seealso>
        public string message { get; set; }
    }
}
