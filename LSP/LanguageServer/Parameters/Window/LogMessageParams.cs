using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Window
{
    public class LogMessageParams
    {
        public MessageType type { get; set; }
        public string message { get; set; }
    }
}
