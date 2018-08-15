using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.Client
{
    public class Registration
    {
        public string id { get; set; }

        public string method { get; set; }

        public RegistrationOptions registerOptions { get; set; }
    }
}
