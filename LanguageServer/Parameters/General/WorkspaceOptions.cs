namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class WorkspaceOptions
    {
        /// <summary>
        /// The server supports workspace folder.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceFoldersOptions workspaceFolders { get; set; }
    }
}
