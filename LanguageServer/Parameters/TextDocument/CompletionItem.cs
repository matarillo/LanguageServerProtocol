using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c> and <c>completionItem/resolve</c>
    /// </summary>
    /// <seealso>Spec 3.2.0</seealso>
    public class CompletionItem
    {
        public string label { get; set; }

        public CompletionItemKind? kind { get; set; }

        public string detail { get; set; }

        public string documentation { get; set; }

        /// <summary>
        /// Indicates if this item is deprecated.
        /// </summary>
        /// <seealso>Spec 3.7.2</seealso>
        public bool? deprecated { get; set; }

        /// <summary>
        /// Select this item when showing.
        /// </summary>
        /// <remarks>
        /// Note that only one completion item can be selected and that the tool / client decides which item that is.
        /// The rule is that the <b>first</b> item of those that match best is selected.
        /// </remarks>
        /// <seealso>Spec 3.9.0</seealso>
        public bool? preselect { get; set; }

        public string sortText { get; set; }

        public string filterText { get; set; }

        public string insertText { get; set; }

        public InsertTextFormat? insertTextFormat { get; set; }

        public TextEdit textEdit { get; set; }

        public TextEdit[] additionalTextEdits { get; set; }

        /// <summary>
        /// An optional set of characters that when pressed while this completion is active
        /// will accept it first and then type that character.
        /// </summary>
        /// <remarks>
        /// Note that all commit characters should have <c>length=1</c> and that superfluous characters will be ignored.
        /// </remarks>
        /// <seealso>Spec 3.2.0</seealso>
        public string[] commitCharacters { get; set; }

        public Command command { get; set; }

        public dynamic data { get; set; }
    }
}
