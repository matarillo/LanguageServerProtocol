namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>.
    /// </summary>
    /// <seealso>Spec 3.3.0</seealso>
    public class SignatureInformationCapabilities
    {
        /// <summary>
        /// Client supports the follow content formats for the documentation property.
        /// </summary>
        /// <remarks>
        /// The order describes the preferred format of the client.
        /// </remarks>
        /// <value>
        /// See <see cref="LanguageServer.Parameters.MarkupKind"/> for an enumeration of standardized kinds.
        /// </value>
        /// <seealso>Spec 3.3.0</seealso>
        /// <seealso cref="LanguageServer.Parameters.MarkupKind"/>
        public string[] documentationFormat { get; set; }
    }
}
