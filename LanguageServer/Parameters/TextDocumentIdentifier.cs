using System;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/didChange</c>,
    /// <c>textDocument/willSave</c>,
    /// <c>textDocument/willSaveWaitUntil</c>,
    /// <c>textDocument/didSave</c>,
    /// <c>textDocument/didClose</c>,
    /// <c>textDocument/completion</c>,
    /// <c>textDocument/hover</c>,
    /// <c>textDocument/references</c>,
    /// <c>textDocument/documentHighlight</c>,
    /// <c>textDocument/documentSymbol</c>,
    /// <c>textDocument/formatting</c>,
    /// <c>textDocument/rangeFormatting</c>,
    /// <c>textDocument/onTypeFormatting</c>,
    /// <c>textDocument/definition</c>,
    /// <c>textDocument/codeAction</c>,
    /// <c>textDocument/codeLens</c>,
    /// <c>textDocument/documentLink</c>,
    /// <c>textDocument/rename</c>, and
    /// <c>workplace/applyEdit</c>
    /// </summary>
    public class TextDocumentIdentifier
    {
        public Uri uri { get; set; }
    }
}