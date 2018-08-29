using LanguageServer.Parameters.TextDocument;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.4.0</seealso>
    public class CompletionItemKindCapabilities
    {
        /// <summary>
        /// The completion item kind values the client supports.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When this
        /// property exists the client also guarantees that it will
        /// handle values outside its set gracefully and falls back
        /// to a default value when unknown.
        /// </para>
        /// <para>
        /// If this property is not present the client only supports
        /// the completion items kinds from <c>Text</c> to <c>Reference</c> as defined in
        /// the initial version of the protocol.
        /// </para>
        /// </remarks>
        /// <seealso>Spec 3.4.0</seealso>
        public CompletionItemKind[] valueSet { get; set; }
    }
}
