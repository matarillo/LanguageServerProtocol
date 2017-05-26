using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public interface INumberOrObject
    {
        bool IsNumber { get; }
        bool IsObject { get; }
        long Number { get; set; }
        object Object { get; set; }
        Type ObjectType { get; }
    }
}
