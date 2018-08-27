namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class TextDocumentClientCapabilities
    {
        public SynchronizationCapabilities synchronization { get; set; }

        public CompletionCapabilities completion { get; set; }

        public RegistrationCapabilities hover { get; set; }

        public RegistrationCapabilities signatureHelp { get; set; }

        public RegistrationCapabilities references { get; set; }

        public RegistrationCapabilities documentHighlight { get; set; }

        public RegistrationCapabilities documentSymbol { get; set; }

        public RegistrationCapabilities formatting { get; set; }

        public RegistrationCapabilities rangeFormatting { get; set; }

        public RegistrationCapabilities onTypeFormatting { get; set; }

        public RegistrationCapabilities definition { get; set; }

        public RegistrationCapabilities codeAction { get; set; }

        public RegistrationCapabilities codeLens { get; set; }

        public RegistrationCapabilities documentLink { get; set; }

        public RegistrationCapabilities rename { get; set; }
    }
}
