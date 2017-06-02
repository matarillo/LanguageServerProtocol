using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Window
{
    public class ShowMessageRequestParams
    {
        public MessageType type { get; set; }
        public string message { get; set; }
        public MessageActionItem[] actions { get; set; }
    }
}
