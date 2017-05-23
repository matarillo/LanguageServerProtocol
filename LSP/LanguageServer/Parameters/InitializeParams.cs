using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters
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

    public class InitializeError
    {
        public bool retry { get; set; }
    }
}
