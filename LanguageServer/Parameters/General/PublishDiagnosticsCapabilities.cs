namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.7.0</seealso>
    public class PublishDiagnosticsCapabilities
    {
        /// <summary>
        /// Whether the clients accepts diagnostics with related information.
        /// </summary>
        /// <seealso>Spec 3.7.0</seealso>
        public bool? relatedInformation { get; set; }
    }
}
