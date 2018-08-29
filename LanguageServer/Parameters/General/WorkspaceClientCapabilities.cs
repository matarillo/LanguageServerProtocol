namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.4.0</seealso>
    public class WorkspaceClientCapabilities
    {
        /// <summary>
        /// The client supports applying batch edits to the workspace by supporting
        /// the request <c>workspace/applyEdit</c>
        /// </summary>
        public bool? applyEdit { get; set; }

        /// <summary>
        /// Capabilities specific to <c>WorkspaceEdit</c>s
        /// </summary>
        public EditCapabilities workspaceEdit { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>workspace/didChangeConfiguration</c> notification.
        /// </summary>
        public RegistrationCapabilities didChangeConfiguration { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>workspace/didChangeWatchedFiles</c> notification.
        /// </summary>
        public RegistrationCapabilities didChangeWatchedFiles { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>workspace/symbol</c> request.
        /// </summary>
        /// <seealso>Spec 3.4.0</seealso>
        public SymbolCapabilities symbol { get; set; }

        /// <summary>
        /// Capabilities specific to the <c>workspace/executeCommand</c> request.
        /// </summary>
        public RegistrationCapabilities executeCommand { get; set; }
    }
}
