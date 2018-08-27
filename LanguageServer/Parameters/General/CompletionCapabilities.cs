namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class CompletionCapabilities : RegistrationCapabilities
    {
        public CompletionItemCapabilities completionItem { get; set; }
    }
}
