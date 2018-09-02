namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A code action represents a change that can be performed in code, e.g. to fix a problem or to refactor code.
    /// </para>
    /// <para>
    /// A CodeAction must set either <c>edit</c> and/or a <c>command</c>.
    /// If both are supplied, the <c>edit</c> is applied first, then the <c>command</c> is executed.
    /// </para>
    /// </remarks>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeAction
    {
        /// <summary>
        /// A short, human-readable, title for this code action.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public string title { get; set; }

        /// <summary>
        /// The kind of the code action.
        /// </summary>
        /// <remarks>
        /// Used to filter code actions.
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.CodeActionKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso cref="LanguageServer.Parameters.CodeActionKind"/>
        /// <seealso>Spec 3.8.0</seealso>
        public string kind { get; set; }

        /// <summary>
        /// The diagnostics that this code action resolves.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public Diagnostic[] diagnostics { get; set; }

        /// <summary>
        /// The workspace edit this code action performs.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public WorkspaceEdit edit { get; set; }

        /// <summary>
        /// A command this code action executes.
        /// </summary>
        /// <remarks>
        /// If a code action provides an edit and a command, first the edit is executed and then the command.
        /// </remarks>
        /// <seealso>Spec 3.8.0</seealso>
        public Command command { get; set; }
    }
}
