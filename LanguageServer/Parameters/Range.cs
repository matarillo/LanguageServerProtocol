namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/didChange</c>,
    /// <c>textDocument/willSaveWaitUntil</c>,
    /// <c>textDocument/completion</c>,
    /// <c>textDocument/hover</c>,
    /// <c>textDocument/references</c>,
    /// <c>textDocument/documentHighlight</c>,
    /// <c>textDocument/formatting</c>,
    /// <c>textDocument/rangeFormatting</c>,
    /// <c>textDocument/codeAction</c>,
    /// <c>textDocument/codeLens</c>,
    /// <c>textDocument/documentLink</c>,
    /// <c>textDocument/publishDiagnostics</c>,
    /// <c>documentLink/resolve</c>,
    /// <c>workspace/applyEdit</c>, and
    /// <c>workspace/symbol</c>
    /// </summary>
    public class Range
    {
        public Position start { get; set; }
        public Position end { get; set; }
    }
}