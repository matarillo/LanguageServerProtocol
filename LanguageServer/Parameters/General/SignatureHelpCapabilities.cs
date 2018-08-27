namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>.
    /// </summary>
    /// <seealso>Spec 3.3.0</seealso>
    public class SignatureHelpCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// The client supports the following <c>SignatureInformation</c> specific properties.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public SignatureInformationCapabilities signatureInformation { get; set; }
    }
}
