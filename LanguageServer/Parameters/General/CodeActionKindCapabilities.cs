namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeActionKindCapabilities
    {
        /// <summary>
        /// The code action kind values the client supports.
        /// </summary>
        /// <remarks>
        /// When this property exists the client also guarantees that it will
        /// handle values outside its set gracefully and falls back
        /// to a default value when unknown.
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.CodeActionKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.8.0</seealso>
        /// <seealso cref="LanguageServer.Parameters.CodeActionKind"/>
        public string[] valueSet { get; set; }
    }
}
