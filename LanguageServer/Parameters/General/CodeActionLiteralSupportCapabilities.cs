namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeActionLiteralSupportCapabilities
    {
        /// <summary>
        /// The code action kind is support with the following value set.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionKindCapabilities codeActionKind { get; set; }
    }
}
