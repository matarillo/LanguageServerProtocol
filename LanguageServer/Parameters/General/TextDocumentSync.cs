using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class TextDocumentSync : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="TextDocumentSyncKind"/> to a <see cref="TextDocumentSync"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TextDocumentSync(TextDocumentSyncKind value)
            => new TextDocumentSync(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="TextDocumentSyncOptions"/> to a <see cref="TextDocumentSync"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TextDocumentSync(TextDocumentSyncOptions value)
            => new TextDocumentSync(value);

        /// <summary>
        /// Initializes a new instance of <c>TextDocumentSync</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public TextDocumentSync(TextDocumentSyncKind value)
        {
            Type = typeof(TextDocumentSyncKind);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>TextDocumentSync</c>  with the specified value.
        /// </summary>
        public TextDocumentSync(TextDocumentSyncOptions value)
        {
            Type = typeof(TextDocumentSyncOptions);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="TextDocumentSyncKind"/>.
        /// </summary>
        public bool IsTextDocumentSyncKind => Type == typeof(TextDocumentSyncKind);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="TextDocumentSyncOptions"/>.
        /// </summary>
        public bool IsTextDocumentSyncOptions => Type == typeof(TextDocumentSyncOptions);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="TextDocumentSyncKind"/>.
        /// </summary>
        public TextDocumentSyncKind TextDocumentSyncKind => GetValue<TextDocumentSyncKind>();

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="TextDocumentSyncOptions"/>.
        /// </summary>
        public TextDocumentSyncOptions TextDocumentSyncOptions => GetValue<TextDocumentSyncOptions>();
    }
}
