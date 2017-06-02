using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Workspace
{
    public class DidChangeWatchedFilesParams
    {
        public FileEvent[] changes { get; set; }
    }
}
