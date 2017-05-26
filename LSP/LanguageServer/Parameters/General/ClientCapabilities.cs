namespace LanguageServer.Parameters.General
{
    public class ClientCapabilities
    {
        public WorkspaceClientCapabilities workspace { get; set; }

        public TextDocumentClientCapabilities textDocument { get; set; }

        public dynamic experimental { get; set; }
    }

    public class WorkspaceClientCapabilities
    {
        public bool? applyEdit { get; set; }

        public EditCapabilities workspaceEdit { get; set; }

        public RegistrationCapabilities didChangeConfiguration { get; set; }

        public RegistrationCapabilities didChangeWatchedFiles { get; set; }

        public RegistrationCapabilities symbol { get; set; }

        public RegistrationCapabilities executeCommand { get; set; }
    }

    public class EditCapabilities
    {
        public bool? documentChanges { get; set; }
    }

    public class RegistrationCapabilities
    {
        public bool? dynamicRegistration { get; set; }
    }

    public class TextDocumentClientCapabilities
    {
        public SynchronizationCapabilities synchronization { get; set; }

        public CompletionCapabilities completion { get; set; }

        public RegistrationCapabilities hover { get; set; }

        public RegistrationCapabilities signatureHelp { get; set; }

        public RegistrationCapabilities references { get; set; }

        public RegistrationCapabilities documentHighlight { get; set; }

        public RegistrationCapabilities documentSymbol { get; set; }

        public RegistrationCapabilities formatting { get; set; }

        public RegistrationCapabilities rangeFormatting { get; set; }

        public RegistrationCapabilities onTypeFormatting { get; set; }

        public RegistrationCapabilities definition { get; set; }

        public RegistrationCapabilities codeAction { get; set; }

        public RegistrationCapabilities codeLens { get; set; }

        public RegistrationCapabilities documentLink { get; set; }

        public RegistrationCapabilities rename { get; set; }
    }

    public class SynchronizationCapabilities : RegistrationCapabilities
    {
        public bool? willSave { get; set; }

        public bool? willSaveWaitUntil { get; set; }

        public bool? didSave { get; set; }
    }

    public class CompletionCapabilities : RegistrationCapabilities
    {
        public CompletionItemCapabilities completionItem { get; set; }
    }

    public class CompletionItemCapabilities
    {
        public bool? snippetSupport { get; set; }
    }
}