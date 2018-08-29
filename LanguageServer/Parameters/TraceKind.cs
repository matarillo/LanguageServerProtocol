namespace LanguageServer.Parameters
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso cref="LanguageServer.Parameters.General.InitializeParams.trace"/>
    public static class TraceKind
    {
        /// <summary>
        /// trace is disabled.
        /// </summary>
        public const string Off = "off";

        /// <summary>
        /// trace is partially enabled.
        /// </summary>
        public const string Messages = "messages";

        /// <summary>
        /// trace is fully enabled.
        /// </summary>
        public const string Verbose = "verbose";
    }
}
