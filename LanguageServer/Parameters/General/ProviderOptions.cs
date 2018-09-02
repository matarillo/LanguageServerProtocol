using LanguageServer.Parameters.Client;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// The original spec describes the intersection type
    /// <c>(TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation merges their types into this class.
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public class ProviderOptions
    {
        /// <summary>
        /// A document selector to identify the scope of the registration. If set to null
        /// the document selector provided on the client side will be used.
        /// </summary>
        /// <remarks>
        /// Merged from <see cref="TextDocumentRegistrationOptions"/>.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public DocumentFilter[] documentSelector { get; set; }

        /// <summary>
        /// The id used to register the request. The id can be used to deregister
        /// the request again.
        /// </summary>
        /// <remarks>
        /// Merged from <c>StaticRegistrationOptions</c>.
        /// </remarks>
        /// <seealso cref="Registration.id"/>
        /// <seealso>Spec 3.6.0</seealso>
        public string id { get; set; }
    }
}
