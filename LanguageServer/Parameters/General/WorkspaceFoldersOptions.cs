namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class WorkspaceFoldersOptions
    {
        /// <summary>
        /// The server has support for workspace folders
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool? supported { get; set; }

        /// <summary>
        /// Whether the server wants to receive workspace folder change notifications.
        /// </summary>
        /// <remarks>
        /// If a strings is provided the string is treated as a ID
        /// under which the notification is registered on the client
        /// side.The ID can be used to unregister for these events
        /// using the <c>client/unregisterCapability</c> request.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public ChangeNotificationsOptions changeNotifications { get; set; }
    }
}
