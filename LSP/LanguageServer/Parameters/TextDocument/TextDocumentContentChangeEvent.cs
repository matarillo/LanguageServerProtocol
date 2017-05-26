namespace LanguageServer.Parameters.TextDocument
{
    public class TextDocumentContentChangeEvent
    {
        public Range range { get; set; }

        public long? rangeLength { get; set; }

        public string text { get; set; }
    }
}