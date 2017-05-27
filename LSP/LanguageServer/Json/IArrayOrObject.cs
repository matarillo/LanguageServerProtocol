using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public interface IArrayOrObject
    {
        bool IsArray { get; }
        bool IsObject { get; }
        object[] Array { get; set; }
        object Object { get; set; }
        Type ArrayElementType { get; }
        Type ObjectType { get; }
    }
}
