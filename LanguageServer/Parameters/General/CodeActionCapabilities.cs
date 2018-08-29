namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeActionCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// The client support code action literals as a valid
        /// response of the `textDocument/codeAction` request.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionLiteralSupportCapabilities codeActionLiteralSupport { get; set; }
    }
}
