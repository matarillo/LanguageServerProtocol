using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    public class CompletionResult : Either
    {
        public static implicit operator CompletionResult(CompletionItem[] value)
            => new CompletionResult(value);

        public static implicit operator CompletionResult(CompletionList value)
            => new CompletionResult(value);

        public CompletionResult(CompletionItem[] value)
        {
            Type = typeof(CompletionItem[]);
            Value = value;
        }

        public CompletionResult(CompletionList value)
        {
            Type = typeof(CompletionList);
            Value = value;
        }

        public bool IsCompletionItemArray => Type == typeof(CompletionItem[]);

        public bool IsCompletionList => Type == typeof(CompletionList);

        public CompletionItem[] CompletionItemArray => GetValue<CompletionItem[]>();

        public CompletionList CompletionList => GetValue<CompletionList>();
    }
}
