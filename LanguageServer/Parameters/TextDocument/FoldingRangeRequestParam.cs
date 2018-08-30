namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/foldingRange</c>
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public class FoldingRangeRequestParam
    {
        /// <summary>
        /// The text document.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public TextDocumentIdentifier textDocument { get; set; }
    }
}
