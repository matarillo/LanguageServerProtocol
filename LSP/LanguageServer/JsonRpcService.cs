using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LanguageServer
{
    public class JsonRpcService
    {
        public Connection Connection { get; set; }

        public CancellationToken CancellationToken { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class JsonRpcMethodAttribute : Attribute
    {
        private string _method;

        public JsonRpcMethodAttribute(string method)
        {
            _method = method;
        }

        public string Method
        {
            get => _method;
        }
    }
}
