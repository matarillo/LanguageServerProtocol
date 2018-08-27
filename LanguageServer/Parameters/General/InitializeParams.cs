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
        public string trace { get; set; }
    }
}
