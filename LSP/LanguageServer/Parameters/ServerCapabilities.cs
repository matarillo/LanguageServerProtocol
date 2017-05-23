using LanguageServer.Json;

namespace LanguageServer.Parameters
{
    public class ServerCapabilities
    {
        public NumberOrObject<TextDocumentSync> textDocumentSync { get; set; }

        public bool? hoverProvider { get; set; }

        public CompletionOptions completionProvider { get; set; }

        public SignatureHelpOptions signatureHelpProvider { get; set; }

        public bool? definitionProvider { get; set; }

        public bool? referencesProvider { get; set; }

        public bool? documentHighlightProvider { get; set; }

        public bool? documentSymbolProvider { get; set; }

        public bool? workspaceSymbolProvider { get; set; }

        public bool? codeActionProvider { get; set; }

        public CodeLensOptions codeLensProvider { get; set; }

        public bool? documentFormattingProvider { get; set; }

        public bool? documentRangeFormattingProvider { get; set; }

        public DocumentOnTypeFormattingOptions documentOnTypeFormattingProvider { get; set; }

        public bool? renameProvider { get; set; }

        public DocumentLinkOptions documentLinkProvider { get; set; }

        public ExecuteCommandOptions executeCommandProvider { get; set; }

        public dynamic experimental { get; set; }
    }

    public class TextDocumentSync
    {
        public bool? openClose { get; set; }
        public TextDocumentSyncKind? change { get; set; }
        public bool? willSave { get; set; }
        public bool? willSaveWaitUntil { get; set; }
        public SaveOptions save { get; set; }
    }

    public enum TextDocumentSyncKind
    {
        None = 0,
        Full = 1,
        Incremental = 2,
    }

    public class SaveOptions
    {
        public bool? includeText { get; set; }
    }

    public class CompletionOptions
    {
        public bool? resolveProvider { get; set; }

        public string[] triggerCharacters { get; set; }
    }

    public class SignatureHelpOptions
    {
        public string[] triggerCharacters { get; set; }
    }

    public class CodeLensOptions
    {
        public bool? resolveProvider { get; set; }
    }

    public class DocumentOnTypeFormattingOptions
    {
        public string firstTriggerCharacter { get; set; }

        public string[] moreTriggerCharacter { get; set; }
    }

    public class DocumentLinkOptions
    {
        public bool? resolveProvider { get; set; }
    }

    public class ExecuteCommandOptions
    {
        public string[] commands { get; set; }
    }
}