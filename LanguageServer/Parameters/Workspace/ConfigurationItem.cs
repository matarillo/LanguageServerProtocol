using System;

namespace LanguageServer.Parameters.Workspace
{
    /// <summary>
    /// For <c>workspace/configuration</c>
    /// </summary>
    /// <remarks>
    /// A <c>ConfigurationItem</c> consist of the configuration section to ask for
    /// and an additional scope URI. 
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public class ConfigurationItem
    {
        /// <summary>
        /// The scope to get the configuration section for.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public Uri scopeUri { get; set; }

        /// <summary>
        /// The configuration section asked for.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public string section { get; set; }
    }
}
