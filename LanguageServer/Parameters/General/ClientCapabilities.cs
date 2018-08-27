namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class ClientCapabilities
    {
        public WorkspaceClientCapabilities workspace { get; set; }

        public TextDocumentClientCapabilities textDocument { get; set; }

        public dynamic experimental { get; set; }
    }
}
