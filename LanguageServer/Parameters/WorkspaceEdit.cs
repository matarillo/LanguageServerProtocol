using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{

    /// <summary>
    /// For <c>textDocument/rename</c> and <c>workspace/applyEdit</c>
    /// </summary>
    /// <remarks>
    /// A workspace edit represents changes to many resources managed in the workspace.
    /// The edit should either provide <c>changes</c> or <c>documentChanges</c>.
    /// If the client can handle versioned document edits and if <c>documentChanges</c> are present,
    /// the latter are preferred over <c>changes</c>.
    /// </remarks>
    /// <seealso>Spec 3.1.0</seealso>
    public class WorkspaceEdit
    {
        /// <summary>
        /// Holds changes to existing resources.
        /// </summary>
        public Dictionary<Uri, TextEdit[]> changes { get; set; }

        /// <summary>
        /// An array of <c>TextDocumentEdit</c>s to express changes to n different text documents
        /// where each text document edit addresses a specific version of a text document.
        /// Whether a client supports versioned document edits is expressed
        /// via <c>WorkspaceClientCapabilities.workspaceEdit.documentChanges</c>.
        /// </summary>
        public TextDocumentEdit[] documentChanges { get; set; }
    }
}
