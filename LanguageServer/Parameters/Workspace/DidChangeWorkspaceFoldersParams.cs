namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>workspace/didChangeWorkspaceFolders</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class DidChangeWorkspaceFoldersParams
    {
        /// <summary>
        /// The actual workspace folder change event.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceFoldersChangeEvent @event { get; set; }
    }
}
