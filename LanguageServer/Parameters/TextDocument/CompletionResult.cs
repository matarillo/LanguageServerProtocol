using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    public class CompletionResult : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="T:LanguageServer.Parameters.TextDocument.CompletionItem[]"/> to a <see cref="CompletionResult"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CompletionResult(CompletionItem[] value)
            => new CompletionResult(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="CompletionList"/> to a <see cref="CompletionResult"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CompletionResult(CompletionList value)
            => new CompletionResult(value);

        /// <summary>
        /// Initializes a new instance of <c>CompletionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public CompletionResult(CompletionItem[] value)
        {
            Type = typeof(CompletionItem[]);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>CompletionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public CompletionResult(CompletionList value)
        {
            Type = typeof(CompletionList);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.CompletionItem[]"/>.
        /// </summary>
        public bool IsCompletionItemArray => Type == typeof(CompletionItem[]);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="CompletionList"/>.
        /// </summary>
        public bool IsCompletionList => Type == typeof(CompletionList);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.CompletionItem[]"/>.
        /// </summary>
        public CompletionItem[] CompletionItemArray => GetValue<CompletionItem[]>();

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="CompletionList"/>.
        /// </summary>
        public CompletionList CompletionList => GetValue<CompletionList>();
    }
}
