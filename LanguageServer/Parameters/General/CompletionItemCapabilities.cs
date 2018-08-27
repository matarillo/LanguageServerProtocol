namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class CompletionItemCapabilities
    {
        public bool? snippetSupport { get; set; }

        /// <summary>
        /// Client supports commit characters on a completion item.
        /// </summary>
        /// <seealso>Spec 3.2.0</seealso>
        public bool? commitCharactersSupport { get; set; }
    }
}
