using System;

namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>initialize</c> and <c>workspace/workspaceFolders</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class WorkspaceFolder
    {
        /// <summary>
        /// The associated URI for this workspace folder.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Uri uri { get; set; }

        /// <summary>
        /// The name of the workspace folder.
        /// </summary>
        /// <remarks>
        /// Defaults to the uri's basename.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public string name { get; set; }
    }
}
