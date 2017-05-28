using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public sealed class NumberOrObject<TNumber, TObject> : Either<TNumber, TObject>
        where TNumber : struct, IComparable
    {
        public static implicit operator NumberOrObject<TNumber, TObject>(TNumber left)
            => new NumberOrObject<TNumber, TObject>(left);

        public static implicit operator NumberOrObject<TNumber, TObject>(TObject right)
            => new NumberOrObject<TNumber, TObject>(right);

        public NumberOrObject()
        {
        }

        public NumberOrObject(TNumber left) : base(left)
        {
        }

        public NumberOrObject(TObject right) : base(right)
        {
        }

        protected override EitherTag OnDeserializing(JsonDataType jsonType)
        {
            return
                (jsonType == JsonDataType.Number) ? EitherTag.Left :
                (jsonType == JsonDataType.Object) ? EitherTag.Right :
                EitherTag.None;
        }
    }
}
