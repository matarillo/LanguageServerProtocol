using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Workspace
{
    public class ExecuteCommandParams
    {
        public string command { get; set; }
        public dynamic[] arguments { get; set; }
    }
}
