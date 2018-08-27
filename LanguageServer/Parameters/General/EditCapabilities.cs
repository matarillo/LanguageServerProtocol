namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class EditCapabilities
    {
        /// <summary>
        /// The client supports versioned document changes in <c>WorkspaceEdit</c>s
        /// </summary>
        public bool? documentChanges { get; set; }
    }
}
