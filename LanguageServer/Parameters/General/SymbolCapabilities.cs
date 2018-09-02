namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// Capabilities specific to the <c>workspace/symbol</c> request.
    /// </remarks>
    /// <seealso>Spec 3.10.0</seealso>
    public class SymbolCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// Specific capabilities for the <c>SymbolKind</c> in the <c>workspace/symbol</c> request.
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public SymbolKindCapabilities symbolKind { get; set; }

        /// <summary>
        /// The client support hierarchical document symbols.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public bool? hierarchicalDocumentSymbolSupport { get; set; }
    }
}
