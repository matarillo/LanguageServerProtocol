using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer
{
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
