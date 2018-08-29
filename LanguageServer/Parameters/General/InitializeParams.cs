using LanguageServer.Parameters.Workspace;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class InitializeParams
    {
        /// <summary>
        /// The process Id of the parent process that started the server.
        /// </summary>
        public int? processId { get; set; }

        /// <summary>
        /// The rootUri of the workspace.
        /// </summary>
        public Uri rootUri { get; set; }

        /// <summary>
        /// User provided initialization options.
        /// </summary>
        public dynamic initializationOptions { get; set; }

        /// <summary>
        /// The capabilities provided by the client (editor or tool)
        /// </summary>
        public ClientCapabilities capabilities { get; set; }

        /// <summary>
        /// The initial trace setting.
        /// </summary>
        /// <remarks>
        /// If omitted trace is disabled ('off').
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.TraceKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso cref="LanguageServer.Parameters.TraceKind"/>
        public string trace { get; set; }

        /// <summary>
        /// The workspace folders configured in the client when the server starts.
        /// </summary>
        /// <remarks>
        /// This property is only available if the client supports workspace folders.
        /// It can be <c>null</c> if the client supports workspace folders but none are
        /// configured.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public WorkspaceFolder[] workspaceFolders { get; set; }
    }
}
