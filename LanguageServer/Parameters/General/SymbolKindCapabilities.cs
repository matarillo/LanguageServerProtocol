namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// Specific capabilities for the <c>SymbolKind</c> in the <c>workspace/symbol</c> request.
    /// </remarks>
    /// <seealso>Spec 3.4.0</seealso>
    public class SymbolKindCapabilities
    {
        /// <summary>
        /// The symbol kind values the client supports.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When this property exists the client also guarantees that it will
        /// handle values outside its set gracefully and falls back
        /// to a default value when unknown.
        /// </para>
        /// <para>
        /// If this property is not present the client only supports
        /// the symbol kinds from <c>File</c> to <c>Array</c> as defined in
        /// the initial version of the protocol.
        /// </para>
        /// </remarks>
        /// <seealso>Spec 3.4.0</seealso>
        public SymbolKind[] valueSet { get; set; }
    }
}
