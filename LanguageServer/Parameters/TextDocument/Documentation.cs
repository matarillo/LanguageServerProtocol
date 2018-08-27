using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>,
    /// <c>textDocument/completion</c>, and
    /// <c>completionItem/resolve</c>
    /// </summary>
    /// <remarks>
    /// A human-readable string that represents a doc-comment.
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class Documentation : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="string"/> to a <see cref="Documentation"/>
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.3.0</seealso>
        public static implicit operator Documentation(string value)
            => new Documentation(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="MarkupContent"/> to a <see cref="Documentation"/>
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.3.0</seealso>
        public static implicit operator Documentation(MarkupContent value)
            => new Documentation(value);

        /// <summary>
        /// Initializes a new instance of <c>CompletionItemDocumentation</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation(string value)
        {
            Type = typeof(string);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>CompletionItemDocumentation</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation(MarkupContent value)
        {
            Type = typeof(MarkupContent);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="string"/>.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public bool IsString => Type == typeof(string);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="MarkupContent"/>.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public bool IsMarkupContent => Type == typeof(MarkupContent);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="string"/>.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public string String => GetValue<string>();

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="MarkupContent"/>.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public MarkupContent MarkupContent => GetValue<MarkupContent>();
    }
}
