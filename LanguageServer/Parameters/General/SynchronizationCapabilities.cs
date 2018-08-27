namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    public class SynchronizationCapabilities : RegistrationCapabilities
    {
        public bool? willSave { get; set; }

        public bool? willSaveWaitUntil { get; set; }

        public bool? didSave { get; set; }
    }
}
