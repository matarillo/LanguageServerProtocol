using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/documentSymbol</c> and <c>workspace/symbol</c>
    /// </summary>
    public class SymbolInformation
    {
        /// <summary>
        /// The name of this symbol.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The kind of this symbol.
        /// </summary>
        public SymbolKind kind { get; set; }

        /// <summary>
        /// The location of this symbol.
        /// </summary>
        /// <remarks>
        /// The location's range is used by a tool
        /// to reveal the location in the editor.If the symbol is selected in the
        /// tool the range's start information is used to position the cursor. So
        /// the range usually spans more then the actual symbol's name and does
        /// normally include things like visibility modifiers.
        /// </remarks>
        public Location location { get; set; }

        /// <summary>
        /// The name of the symbol containing this symbol.
        /// </summary>
        /// <remarks>
        /// This information is for
        /// user interface purposes (e.g.to render a qualifier in the user interface
        /// if necessary). It can't be used to re-infer a hierarchy for the document
        /// symbols.
        /// </remarks>
        public string containerName { get; set; }
    }
}
