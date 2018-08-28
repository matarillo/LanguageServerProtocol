using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>workspace/symbol</c>
    /// </summary>
    public class WorkspaceSymbolParams
    {
        public string query { get; set; }
    }
}
