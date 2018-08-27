namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class CompletionCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// The client supports the following <c>CompletionItem</c> specific capabilities.
        /// </summary>
        public CompletionItemCapabilities completionItem { get; set; }
    }
}
