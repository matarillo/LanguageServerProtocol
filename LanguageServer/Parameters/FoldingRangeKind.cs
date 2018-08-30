namespace LanguageServer.Parameters
{
    /// <summary>
    /// Enum of known range kinds
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public static class FoldingRangeKind
    {
        /// <summary>
        /// Folding range for a comment
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public const string Comment = "comment";

        /// <summary>
        /// Folding range for a imports or includes
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public const string Imports = "imports";

        /// <summary>
        /// Folding range for a region (e.g. <c>#region</c>)
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public const string Region = "region";
    }
}
