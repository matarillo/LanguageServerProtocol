using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    public class SignatureInformation
    {
        public string label { get; set; }

        public string documentation { get; set; }

        public ParameterInformation[] parameters { get; set; }
    }
}
