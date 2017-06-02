using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Workspace
{
    public class FileEvent
    {
        public Uri uri { get; set; }
        public FileChangeType type { get; set; }
    }
}
