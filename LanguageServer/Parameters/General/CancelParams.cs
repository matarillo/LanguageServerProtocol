using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>$/cancelRequest</c>
    /// </summary>
    public class CancelParams
    {
        /// <summary>
        /// The request id to cancel.
        /// </summary>
        public NumberOrString id { get; set; }
    }
}
