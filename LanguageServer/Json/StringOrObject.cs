using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public sealed class StringOrObject<TObject> : Either<string, TObject>
    {
        public static implicit operator StringOrObject<TObject>(string left)
            => new StringOrObject<TObject>(left);

        public static implicit operator StringOrObject<TObject>(TObject right)
            => new StringOrObject<TObject>(right);

        public StringOrObject()
        {
        }

        public StringOrObject(string left) : base(left)
        {
        }

        public StringOrObject(TObject right) : base(right)
        {
        }

        protected override EitherTag OnDeserializing(JsonDataType jsonType)
        {
            return
                (jsonType == JsonDataType.String) ? EitherTag.Left :
                (jsonType == JsonDataType.Object) ? EitherTag.Right :
                EitherTag.None;
        }
    }
}
