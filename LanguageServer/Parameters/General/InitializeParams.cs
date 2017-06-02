using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.General
{
    public class InitializeParams
    {
        public int? processId { get; set; }

        public Uri rootUri { get; set; }

        public dynamic initializationOptions { get; set; }

        public ClientCapabilities capabilities { get; set; }

        public string trace { get; set; }
    }

    public class InitializeResult
    {
        public ServerCapabilities capabilities { get; set; }
    }

    public class InitializeErrorData
    {
        public bool retry { get; set; }
    }
}
