namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <remarks>
    /// Contains additional diagnostic information about the context in which a code action is run.
    /// </remarks>
    public class CodeActionContext
    {
        /// <summary>
        /// An array of diagnostics.
        /// </summary>
        public Diagnostic[] diagnostics { get; set; }
    }
}
