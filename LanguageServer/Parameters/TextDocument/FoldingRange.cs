namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Represents a folding range.
    /// For <c>textDocument/foldingRange</c>
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public class FoldingRange
    {
        /// <summary>
        /// The zero-based line number from where the folded range starts.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public long startLine { get; set; }

        /// <summary>
        /// The zero-based character offset from where the folded range starts.
        /// </summary>
        /// <remarks>
        /// If not defined, defaults to the length of the start line.
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long? startCharacter { get; set; }

        /// <summary>
        /// The zero-based line number where the folded range ends.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public long endLine { get; set; }

        /// <summary>
        /// The zero-based character offset before the folded range ends.
        /// </summary>
        /// <remarks>
        /// If not defined, defaults to the length of the end line.
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long? endCharacter { get; set; }

        /// <summary>
        /// Describes the kind of the folding range such as <c>comment</c> or <c>region</c>.
        /// </summary>
        /// <remarks>
        /// The kind is used to categorize folding ranges and used by commands like 'Fold all comments'.
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.FoldingRangeKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.10.0</seealso>
        /// <seealso cref="LanguageServer.Parameters.FoldingRangeKind"/>
        public string kind { get; set; }
    }
}
