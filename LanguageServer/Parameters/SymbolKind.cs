using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>textDocument/documentSymbol</c> and <c>workspace/symbol</c>
    /// </summary>
    /// <remarks>
    /// A symbol kind.
    /// </remarks>
    /// <seealso>Spec 3.4.0</seealso>
    public enum SymbolKind
    {
        /// <summary>File</summary>
        File = 1,

        /// <summary>Module</summary>
        Module = 2,

        /// <summary>Namespace</summary>
        Namespace = 3,

        /// <summary>Package</summary>
        Package = 4,

        /// <summary>Class</summary>
        Class = 5,

        /// <summary>Method</summary>
        Method = 6,

        /// <summary>Property</summary>
        Property = 7,

        /// <summary>Field</summary>
        Field = 8,

        /// <summary>Constructor</summary>
        Constructor = 9,

        /// <summary>Enum</summary>
        Enum = 10,

        /// <summary>Interface</summary>
        Interface = 11,

        /// <summary>Function</summary>
        Function = 12,

        /// <summary>Variable</summary>
        Variable = 13,

        /// <summary>Constant</summary>
        Constant = 14,

        /// <summary>String</summary>
        String = 15,

        /// <summary>Number</summary>
        Number = 16,

        /// <summary>Boolean</summary>
        Boolean = 17,

        /// <summary>Array</summary>
        Array = 18,

        /// <summary>Object</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Object = 19,

        /// <summary>Key</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Key = 20,

        /// <summary>Null</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Null = 21,

        /// <summary>EnumMember</summary>
        /// <seealso>Spec 3.4.0</seealso>
        EnumMember = 22,

        /// <summary>Struct</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Struct = 23,

        /// <summary>Event</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Event = 24,

        /// <summary>Operator</summary>
        /// <seealso>Spec 3.4.0</seealso>
        Operator = 25,

        /// <summary>TypeParameter</summary>
        /// <seealso>Spec 3.4.0</seealso>
        TypeParameter = 26,
    }
}
