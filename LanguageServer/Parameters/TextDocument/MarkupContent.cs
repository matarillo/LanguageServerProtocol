namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c> and <c>textDocument/hover</c>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <c>MarkupContent</c> literal represents a string value which content is interpreted base on its
    /// kind flag. Currently the protocol supports <c>plaintext</c> and <c>markdown</c> as markup kinds.
    /// </para>
    /// <para>
    /// If the kind is <c>markdown</c> then the value can contain fenced code blocks like in GitHub issues.
    /// See https://help.github.com/articles/creating-and-highlighting-code-blocks/#syntax-highlighting
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example how such a string can be constructed using JavaScript / TypeScript:
    /// <code lang="typescript">
    /// <![CDATA[
    /// let markdown: MarkdownContent = {
    ///     kind: MarkupKind.Markdown,
    ///     value: [
    ///         '# Header',
    ///         'Some text',
    ///         '```typescript',
    ///         'someCode();',
    ///         '```'
    ///     ].join('\n')
    /// };
    /// ]]>
    /// </code>
    /// </example>
    /// <seealso>Spec 3.3.0</seealso>
    public class MarkupContent
    {
        /// <summary>
        /// The type of the Markup
        /// </summary>
        /// <value>
        /// <list type="bullet">
        /// <item>
        /// <term>plaintext</term>
        /// <description>Plain text is supported as a content format</description>
        /// </item>
        /// <item>
        /// <term>markdown</term>
        /// <description>Markdown is supported as a content format</description>
        /// </item>
        /// </list>
        /// See <see cref="LanguageServer.Parameters.MarkupKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.3.0</seealso>
        /// <seealso cref="LanguageServer.Parameters.MarkupKind"/>
        public string kind { get; set; }

        /// <summary>
        /// The content itself
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public string value { get; set; }
    }
}
