namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// <c>dynamicRegistration</c> property shows whether implementation supports dynamic registration.
    /// If this is set to <c>true</c> the client supports the new
    /// <c>(FoldingRangeProviderOptions &amp; TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>
    /// return value for the corresponding server capability as well.
    /// </remarks>
    /// <seealso>Spec 3.10.0</seealso>
    public class FoldingRangeCapabilities : RegistrationCapabilities
    {
        /// <summary>
        /// The maximum number of folding ranges that the client prefers to receive per document.
        /// </summary>
        /// <remarks>
        /// The value serves as a hint, servers are free to follow the limit.
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public long? rangeLimit { get; set; }

        /// <summary>
        /// If set, the client signals that it only supports folding complete lines.
        /// </summary>
        /// <remarks>
        /// If set, client will ignore specified <c>startCharacter</c>
        /// and <c>endCharacter</c> properties in a FoldingRange.
        /// </remarks>
        /// <seealso>Spec 3.10.0</seealso>
        public bool? lineFoldingOnly { get; set; }
    }
}
