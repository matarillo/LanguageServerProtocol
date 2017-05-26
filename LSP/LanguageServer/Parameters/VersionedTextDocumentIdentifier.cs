namespace LanguageServer.Parameters
{
    public class VersionedTextDocumentIdentifier : TextDocumentIdentifier
    {
        public long version { get; set; }
    }
}