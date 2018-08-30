using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// MarkedString can be used to render human readable text.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is either a markdown string or a code-block that provides a language and a code snippet.
    /// The language identifier is semantically equal to the optional language identifier
    /// in fenced code blocks in GitHub issues.
    /// See https://help.github.com/articles/creating-and-highlighting-code-blocks/#syntax-highlighting
    /// </para>
    /// <para>
    /// The pair of a language and a value is an equivalent to markdown:
    /// <code lang="markdown">
    /// <![CDATA[
    /// ```${language}
    /// ${value}
    /// ```
    /// ]]>
    /// </code>
    /// </para>
    /// <para>
    /// Note that markdown strings will be sanitized - that means html will be escaped.
    /// </para>
    /// <para>
    /// <c>MarkedString</c> is deprecated. use <c>MarkupContent</c> instead.
    /// </para>
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    [Obsolete("MarkedString is deprecated since the spec v3.3.0, please use MarkupContent instead.")]
    public class MarkedString
    {
        /// <summary>
        /// The language in which the code block is written.
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// The code block.
        /// </summary>
        public string value { get; set; }
    }
}
