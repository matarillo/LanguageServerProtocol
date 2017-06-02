using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class SignatureHelp
    {
        public SignatureInformation[] signatures { get; set; }

        public int? activeSignature { get; set; }

        public int? activeParameter { get; set; }
    }
}
