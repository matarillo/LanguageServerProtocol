using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class TextDocumentSync : Either
    {
        public static implicit operator TextDocumentSync(TextDocumentSyncKind value)
            => new TextDocumentSync(value);

        public static implicit operator TextDocumentSync(TextDocumentSyncOptions value)
            => new TextDocumentSync(value);

        public TextDocumentSync(TextDocumentSyncKind value)
        {
            Type = typeof(TextDocumentSyncKind);
            Value = value;
        }

        public TextDocumentSync(TextDocumentSyncOptions value)
        {
            Type = typeof(TextDocumentSyncOptions);
            Value = value;
        }

        public bool IsTextDocumentSyncKind => Type == typeof(TextDocumentSyncKind);

        public bool IsTextDocumentSyncOptions => Type == typeof(TextDocumentSyncOptions);

        public TextDocumentSyncKind TextDocumentSyncKind => GetValue<TextDocumentSyncKind>();

        public TextDocumentSyncOptions TextDocumentSyncOptions => GetValue<TextDocumentSyncOptions>();
    }
}
