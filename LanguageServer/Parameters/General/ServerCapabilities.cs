using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.8.0</seealso>
    public class ServerCapabilities
    {
        /// <summary>
        /// Defines how text documents are synced.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Is either a detailed structure defining each notification or
        /// for backwards compatibility the <c>TextDocumentSyncKind</c> number.
        /// </para>
        /// <para>
        /// If omitted it defaults to <c>TextDocumentSyncKind.None</c>.
        /// </para>
        /// </remarks>
        public TextDocumentSync textDocumentSync { get; set; }

        /// <summary>
        /// The server provides hover support.
        /// </summary>
        public bool? hoverProvider { get; set; }

        /// <summary>
        /// The server provides completion support.
        /// </summary>
        public CompletionOptions completionProvider { get; set; }

        /// <summary>
        /// The server provides signature help support.
        /// </summary>
        public SignatureHelpOptions signatureHelpProvider { get; set; }

        /// <summary>
        /// The server provides goto definition support.
        /// </summary>
        public bool? definitionProvider { get; set; }

        /// <summary>
        /// The server provides Goto Type Definition support.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean typeDefinitionProvider { get; set; }

        /// <summary>
        /// The server provides Goto Implementation support.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean implementationProvider { get; set; }

        /// <summary>
        /// The server provides find references support.
        /// </summary>
        public bool? referencesProvider { get; set; }

        /// <summary>
        /// The server provides document highlight support.
        /// </summary>
        public bool? documentHighlightProvider { get; set; }

        /// <summary>
        /// The server provides document symbol support.
        /// </summary>
        public bool? documentSymbolProvider { get; set; }

        /// <summary>
        /// The server provides workspace symbol support.
        /// </summary>
        public bool? workspaceSymbolProvider { get; set; }

        /// <summary>
        /// The server provides code actions.
        /// </summary>
        /// <remarks>
        /// The <c>CodeActionOptions</c> return type (since version 3.11.0) is only
        /// valid if the client signals code action literal support via the property
        /// <c>textDocument.codeAction.codeActionLiteralSupport</c>.
        /// </remarks>
        public bool? codeActionProvider { get; set; }

        /// <summary>
        /// The server provides code lens.
        /// </summary>
        public CodeLensOptions codeLensProvider { get; set; }

        /// <summary>
        /// The server provides document formatting.
        /// </summary>
        public bool? documentFormattingProvider { get; set; }

        /// <summary>
        /// The server provides document range formatting.
        /// </summary>
        public bool? documentRangeFormattingProvider { get; set; }

        /// <summary>
        /// The server provides document formatting on typing.
        /// </summary>
        public DocumentOnTypeFormattingOptions documentOnTypeFormattingProvider { get; set; }

        /// <summary>
        /// The server provides rename support.
        /// </summary>
        /// <remarks>
        /// RenameOptions may only be specified if the client states that it supports
        /// <c>prepareSupport</c> in its initial <c>initialize</c> request.
        /// </remarks>
        public bool? renameProvider { get; set; }

        /// <summary>
        /// The server provides document link support.
        /// </summary>
        public DocumentLinkOptions documentLinkProvider { get; set; }

        /// <summary>
        /// The server provides color provider support.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptionsOrBoolean colorProvider { get; set; }

        /// <summary>
        /// The server provides execute command support.
        /// </summary>
        public ExecuteCommandOptions executeCommandProvider { get; set; }

        /// <summary>
        /// Workspace specific server capabilities
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceOptions workspace { get; set; }

        /// <summary>
        /// Experimental server capabilities.
        /// </summary>
        public dynamic experimental { get; set; }
    }
}
