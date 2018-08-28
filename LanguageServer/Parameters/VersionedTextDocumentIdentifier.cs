namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/rename</c>,
    /// <c>textDocument/didChange</c>, and
    /// <c>workspace/applyEdit</c>
    /// </summary>
    public class VersionedTextDocumentIdentifier : TextDocumentIdentifier
    {
        public long version { get; set; }
    }
}