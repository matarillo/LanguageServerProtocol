namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class WorkspaceClientCapabilities
    {
        public bool? applyEdit { get; set; }

        public EditCapabilities workspaceEdit { get; set; }

        public RegistrationCapabilities didChangeConfiguration { get; set; }

        public RegistrationCapabilities didChangeWatchedFiles { get; set; }

        public RegistrationCapabilities symbol { get; set; }

        public RegistrationCapabilities executeCommand { get; set; }
    }
}
