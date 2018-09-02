namespace LanguageServer.Parameters
{
    /// <summery>
    /// A set of predefined code action kinds
    /// </summery>
    /// <seealso cref="LanguageServer.Parameters.General.CodeActionKindCapabilities.valueSet"/>
    /// <seealso cref="LanguageServer.Parameters.TextDocument.CodeActionContext.only"/>
    /// <seealso>Spec 3.8.0</seealso>
    public static class CodeActionKind
    {
        /// <summary>
        /// Base kind for quickfix actions: 'quickfix'
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public const string QuickFix = "quickfix";

        /// <summary>
        /// Base kind for refactoring actions: 'refactor'
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public const string Refactor = "refactor";

        /// <summary>
        /// Base kind for refactoring extraction actions: 'refactor.extract'
        /// </summary>
        /// <example>
        /// Example extract actions:
        /// <list type="bullet">
        /// <item><description>Extract method</description></item>
        /// <item><description>Extract function</description></item>
        /// <item><description>Extract variable</description></item>
        /// <item><description>Extract interface from class</description></item>
        /// <item><description>...</description></item>
        /// </list>
        /// </example>
        /// <seealso>Spec 3.8.0</seealso>
        public const string RefactorExtract = "refactor.extract";

        /// <summary>
        /// Base kind for refactoring inline actions: 'refactor.inline'
        /// </summary>
        /// <example>
        /// Example inline actions:
        /// <list type="bullet">
        /// <item><description>Inline function</description></item>
        /// <item><description>Inline variable</description></item>
        /// <item><description>Inline constant</description></item>
        /// <item><description>...</description></item>
        /// </list>
        /// </example>
        /// <seealso>Spec 3.8.0</seealso>
        public const string RefactorInline = "refactor.inline";

        /// <summary>
        /// Base kind for refactoring rewrite actions: 'refactor.rewrite'
        /// </summary>
        /// <example>
        /// Example rewrite actions:
        /// <list type="bullet">
        /// <item><description>Convert JavaScript function to class</description></item>
        /// <item><description>Add or remove parameter</description></item>
        /// <item><description>Encapsulate field</description></item>
        /// <item><description>Make method static</description></item>
        /// <item><description>Move method to base class</description></item>
        /// <item><description>...</description></item>
        /// </list>
        /// </example>
        /// <seealso>Spec 3.8.0</seealso>
        public const string RefactorRewrite = "refactor.rewrite";

        /// <summary>
        /// Base kind for source actions: 'source'
        /// </summary>
        /// <remarks>
        /// Source code actions apply to the entire file.
        /// </remarks>
        /// <seealso>Spec 3.8.0</seealso>
        public const string Source = "source";

        /// <summary>
        /// Base kind for an organize imports source action: 'source.organizeImports'
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public const string SourceOrganizeImports = "source.organizeImports";
    }
}
