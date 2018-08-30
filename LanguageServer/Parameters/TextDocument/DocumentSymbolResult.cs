using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/documentSymbol</c>
    /// </summary>
    /// <seealso>Spec 3.10.0</seealso>
    public class DocumentSymbolResult : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="T:LanguageServer.Parameters.TextDocument.DocumentSymbol[]"/> to a <see cref="DocumentSymbolResult"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.10.0</seealso>
        public static implicit operator DocumentSymbolResult(DocumentSymbol[] value)
            => new DocumentSymbolResult(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="T:LanguageServer.Parameters.TextDocument.SymbolInformation[]"/> to a <see cref="DocumentSymbolResult"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.10.0</seealso>
        public static implicit operator DocumentSymbolResult(SymbolInformation[] value)
            => new DocumentSymbolResult(value);

        /// <summary>
        /// Initializes a new instance of <c>DocumentSymbolResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.10.0</seealso>
        public DocumentSymbolResult(DocumentSymbol[] value)
        {
            Type = typeof(DocumentSymbol[]);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>DocumentSymbolResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.10.0</seealso>
        public DocumentSymbolResult(SymbolInformation[] value)
        {
            Type = typeof(SymbolInformation[]);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.DocumentSymbol[]"/>.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public bool IsDocumentSymbolArray
        {
            get => Type == typeof(DocumentSymbol[]);
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.SymbolInformation[]"/>.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public bool IsSymbolInformationArray
        {
            get => Type == typeof(SymbolInformation[]);
        }

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.DocumentSymbol[]"/>.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public DocumentSymbol[] DocumentSymbolArray
        {
            get => GetValue<DocumentSymbol[]>();
        }

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.SymbolInformation[]"/>.
        /// </summary>
        /// <seealso>Spec 3.10.0</seealso>
        public SymbolInformation[] SymbolImformationArray
        {
            get => GetValue<SymbolInformation[]>();
        }
    }
}
