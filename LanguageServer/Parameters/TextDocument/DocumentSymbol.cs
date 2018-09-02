namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/documentSymbol</c>
    /// </summary>
    /// <remarks>
    /// Represents programming constructs like variables, classes, interfaces etc. that appear in a document.
    /// Document symbols can be hierarchical and they have two ranges:
    /// one that encloses its definition and one that points to its most interesting range,
    /// e.g. the range of an identifier.
    /// </remarks>
    /// <seealso>Spec 3.10.0</seealso>
    public class DocumentSymbol
    {
        /// <summery>
        /// The name of this symbol.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public string name { get; set; }

        /// <summery>
        /// More detail for this symbol, e.g the signature of a function. If not provided the name is used.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public string detail { get; set; }

        /// <summery>
        /// The kind of this symbol.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public SymbolKind kind { get; set; }

        /// <summery>
        /// Indicates if this symbol is deprecated.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public bool? deprecated { get; set; }

        /// <summery>
        /// The range enclosing this symbol not including leading/trailing whitespace but everything else
        /// like comments. This information is typically used to determine if the the clients cursor is
        /// inside the symbol to reveal in the symbol in the UI.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public Range range { get; set; }

        /// <summery>
        /// The range that should be selected and revealed when this symbol is being picked, e.g the name of a function.
        /// Must be contained by the the <c>range</c>.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public Range selectionRange { get; set; }

        /// <summery>
        /// Children of this symbol, e.g. properties of a class.
        /// </summery>
        /// <seealso>Spec 3.10.0</seealso>
        public DocumentSymbol[] children { get; set; }
    }
}
