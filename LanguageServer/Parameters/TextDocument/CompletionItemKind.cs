using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c> and <c>completionItem/resolve</c>
    /// </summary>
    /// <remarks>
    /// The kind of a completion entry.
    /// </remarks>
    /// <seealso>Spec 3.4.0</seealso>
    public enum CompletionItemKind
    {
        /// <summary>Text</summary>
        Text = 1,

        /// <summary>Method</summary>
        Method = 2,

        /// <summary>Function</summary>
        Function = 3,

        /// <summary>Constructor</summary>
        Constructor = 4,

        /// <summary>Field</summary>
        Field = 5,

        /// <summary>Variable</summary>
        Variable = 6,

        /// <summary>Class</summary>
        Class = 7,

        /// <summary>Interface</summary>
        Interface = 8,

        /// <summary>Module</summary>
        Module = 9,

        /// <summary>Property</summary>
        Property = 10,

        /// <summary>Unit</summary>
        Unit = 11,

        /// <summary>Value</summary>
        Value = 12,

        /// <summary>Enum</summary>
        Enum = 13,

        /// <summary>Keyword</summary>
        Keyword = 14,

        /// <summary>Snippet</summary>
        Snippet = 15,

        /// <summary>Color</summary>
        Color = 16,

        /// <summary>File</summary>
        File = 17,

        /// <summary>Reference</summary>
        Reference = 18,

        /// <summary>Folder</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Folder = 19,

        /// <summary>EnumMember</summary>
        /// <seealso>Spec 3.4.0</seealso>
        EnumMember = 20,

        /// <summary>Constant</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Constant = 21,

        /// <summary>Struct</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Struct = 22,

        /// <summary>Event</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Event = 23,

        /// <summary>Operator</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Operator = 24,

        /// <summary>TypeParameter</summary>
        /// <seealso>Spec 3.4.0</seealso>
        TypeParameter = 25,
    }
}
