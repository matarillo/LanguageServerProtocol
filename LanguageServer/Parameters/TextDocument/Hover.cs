namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/hover</c>
    /// </summary>
    /// <remarks>
    /// The result of a hover request.
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class Hover
    {
        /// <summary>
        /// The hover's content
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public HoverContents contents { get; set; }

        /// <summary>
        /// An optional range is a range inside a text document
        /// that is used to visualize a hover, e.g. by changing the background color.
        /// </summary>
        public Range range { get; set; }
    }
}
