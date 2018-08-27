namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class InitializeErrorData
    {
        /// <summary>
        /// Indicates whether the client execute the following retry logic.
        /// </summary>
        /// <remarks>
        /// <list type="number">
        /// <item><description>show the message provided by the <c>ResponseError</c> to the user</description></item>
        /// <item><description>user selects retry or cancel</description></item>
        /// <item><description>if user selected retry the initialize method is sent again</description></item>
        /// </list>
        /// </remarks>
        public bool retry { get; set; }
    }
}
