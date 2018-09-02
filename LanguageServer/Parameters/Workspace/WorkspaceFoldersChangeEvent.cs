namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>workspace/didChangeWorkspaceFolders</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class WorkspaceFoldersChangeEvent
    {
        /// <summary>
        /// The array of added workspace folders
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceFolder[] added { get; set; }

        /// <summary>
        /// The array of the removed workspace folders
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceFolder[] removed { get; set; }
    }
}
