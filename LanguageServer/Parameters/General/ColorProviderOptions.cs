namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// The original spec describes the intersection type
    /// <c>(ColorProviderOptions &amp; TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation merges their types into this class.
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorProviderOptions : ProviderOptions
    {
    }
}
