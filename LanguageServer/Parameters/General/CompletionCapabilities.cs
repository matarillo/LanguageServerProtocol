namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.4.0</seealso>
    public class CompletionCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// The client supports the following <c>CompletionItem</c> specific capabilities.
        /// </summary>
        public CompletionItemCapabilities completionItem { get; set; }

        /// <summary>
        /// The completion item kind values the client supports.
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public CompletionItemKindCapabilities completionItemKind { get; set; }

        /// <summary>
        /// The client supports to send additional context information for a
        /// <c>textDocument/completion</c> request.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public bool? contextSupport { get; set; }
    }
}
