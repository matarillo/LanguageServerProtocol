namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/colorPresentation</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorPresentationParams
    {
        /// <summary>
        /// The text document.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public TextDocumentIdentifier textDocument { get; set; }

        /// <summary>
        /// The color information to request presentations for.
        /// </summary>
        /// <remarks>
        /// The property's name was originally <c>colorInfo</c>, and it has been changed to <c>color</c> since the spec 3.8.0.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public Color color { get; set; }

        /// <summary>
        /// The range where the color would be inserted. Serves as a context.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Range range { get; set; }
    }
}
