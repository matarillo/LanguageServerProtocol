namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>workspace/configuration</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ConfigurationParams
    {
        /// <summary>
        /// The order of the returned configuration settings correspond
        /// to the order of the passed <c>ConfigurationItems</c>
        /// </summary>
        /// <remarks>
        /// (e.g. the first item in the response is the result
        /// for the first configuration item in the params).
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public ConfigurationItem[] items { get; set; }
    }
}
