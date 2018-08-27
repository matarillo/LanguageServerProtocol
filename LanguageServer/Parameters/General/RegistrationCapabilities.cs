namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class RegistrationCapabilities
    {
        /// <summary>
        /// Whether the client supports dynamic registration.
        /// </summary>
        public bool? dynamicRegistration { get; set; }
    }
}
