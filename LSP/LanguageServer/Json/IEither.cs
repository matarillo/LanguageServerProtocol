using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public interface IEither
    {
        bool IsLeft { get; }
        bool IsRight { get; }
        object Left { get; set; }
        object Right { get; set; }
        Type LeftType { get; }
        Type RightType { get; }
        EitherTag OnDeserializing(JsonDataType jsonType);
    }
}
