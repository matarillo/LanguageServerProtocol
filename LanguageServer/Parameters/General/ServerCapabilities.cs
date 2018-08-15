using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    public class ServerCapabilities
    {
        public TextDocumentSync textDocumentSync { get; set; }

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
}