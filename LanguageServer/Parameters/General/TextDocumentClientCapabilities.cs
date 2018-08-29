namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.4.0</seealso>
    public class TextDocumentClientCapabilities
    {
        /// <summary>
        /// Capabilities specific to text document synchronization,
        /// such as <c>textDocument/willSave</c>, <c>textDocument/didSave</c>, etc
        /// </summary>
        public SynchronizationCapabilities synchronization { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/completion</c>
        /// </summary>
        public CompletionCapabilities completion { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/hover</c>
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public HoverCapabilities hover { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/signatureHelp</c>
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public SignatureHelpCapabilities signatureHelp { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/references</c>
        /// </summary>
        public RegistrationCapabilities references { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentHighlight</c>
        /// </summary>
        public RegistrationCapabilities documentHighlight { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentSymbol</c>
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public SymbolCapabilities documentSymbol { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/formatting</c>
        /// </summary>
        public RegistrationCapabilities formatting { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/rangeFormatting</c>
        /// </summary>
        public RegistrationCapabilities rangeFormatting { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/onTypeFormatting</c>
        /// </summary>
        public RegistrationCapabilities onTypeFormatting { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/definition</c>
        /// </summary>
        public RegistrationCapabilities definition { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/codeAction</c>
        /// </summary>
        public RegistrationCapabilities codeAction { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/codeLens</c>
        /// </summary>
        public RegistrationCapabilities codeLens { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/documentLink</c>
        /// </summary>
        public RegistrationCapabilities documentLink { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>textDocument/rename</c>
        /// </summary>
        public RegistrationCapabilities rename { get; set; }
    }
}
