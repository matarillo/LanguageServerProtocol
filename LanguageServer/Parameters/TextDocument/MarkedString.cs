using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// <para>
    /// MarkedString can be used to render human readable text. It is either a markdown string
    /// or a code-block that provides a language and a code snippet. The language identifier
    /// is sematically equal to the optional language identifier in fenced code blocks in GitHub
    /// issues. See https://help.github.com/articles/creating-and-highlighting-code-blocks/#syntax-highlighting
    /// </para>
    /// <para>
    /// The pair of a language and a value is an equivalent to markdown:
    /// </para>
    /// <code>
    /// ```${language}
    /// ${value}
    /// ```
    /// </code>
    /// </summary>
    /// <remarks>
    /// Note that markdown strings will be sanitized - that means html will be escaped.
    /// </remarks>
    public class MarkedString
    {
        public string language { get; set; }

        public string value { get; set; }
    }
}
