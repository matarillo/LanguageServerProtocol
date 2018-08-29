namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/documentColor</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorInformation
    {
        /// <summary>
        /// The range in the document where this color appears.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Range range { get; set; }

        /// <summary>
        /// The actual color value for this color range.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Color color { get; set; }
    }
}
