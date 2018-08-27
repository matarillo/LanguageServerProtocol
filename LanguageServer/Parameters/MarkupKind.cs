namespace LanguageServer.Parameters
{
    /// <summary>
    /// Describes the content type that a client supports in various result literals
    /// like <c>Hover</c>, <c>ParameterInfo</c> or <c>CompletionItem</c>.
    /// </summary>
    /// <remarks>
    /// Please note that <c>MarkupKind</c>s must not start with a <c>$</c>.
    /// This kinds are reserved for internal usage.
    /// </remarks>
    /// <seealso cref="LanguageServer.Parameters.General.CompletionItemCapabilities.documentationFormat"/>
    /// <seealso cref="LanguageServer.Parameters.General.HoverCapabilities.contentFormat"/>
    /// <seealso cref="LanguageServer.Parameters.General.SignatureInformationCapabilities.documentationFormat"/>
    /// <seealso cref="LanguageServer.Parameters.TextDocument.MarkupContent.kind"/>
    /// <seealso>Spec 3.3.0</seealso>
    public static class MarkupKind
    {
        /// <summary>
        /// Plain text is supported as a content format
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public const string PlainText = "plaintext";

        /// <summary>
        /// Markdown is supported as a content format
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public const string Markdown = "markdown";
    }
}
