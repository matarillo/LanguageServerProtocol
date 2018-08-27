using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c> and <c>textDocument/didChange</c>
    /// </summary>
    public enum TextDocumentSyncKind
    {
        /// <summary>
        /// Documents should not be synced at all.
        /// </summary>
        None = 0,
        /// <summary>
        /// Documents are synced by always sending the full content of the document.
        /// </summary>
        Full = 1,
        /// <summary>
        /// Documents are synced by sending the full content on open.
        /// </summary>
        /// <remarks>
        /// After that only incremental updates to the document are send.
        /// </remarks>
        Incremental = 2,
    }
}
