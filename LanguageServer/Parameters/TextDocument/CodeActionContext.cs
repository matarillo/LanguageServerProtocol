namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <remarks>
    /// Contains additional diagnostic information about the context in which a code action is run.
    /// </remarks>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeActionContext
    {
        /// <summary>
        /// An array of diagnostics.
        /// </summary>
        public Diagnostic[] diagnostics { get; set; }

        /// <summary>
        /// Requested kind of actions to return.
        /// </summary>
        /// <remarks>
        /// Actions not of this kind are filtered out by the client before being shown. So servers
        /// can omit computing them.
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.CodeActionKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.8.0</seealso>
        /// <seealso cref="LanguageServer.Parameters.CodeActionKind"/>
        public string[] only { get; set; }
    }
}
