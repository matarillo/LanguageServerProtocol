using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public sealed class ArrayOrObject<TElement, TObject> : Either<TElement[], TObject>
    {
        public static implicit operator ArrayOrObject<TElement, TObject>(TElement[] left)
            => new ArrayOrObject<TElement, TObject>(left);

        public static implicit operator ArrayOrObject<TElement, TObject>(TObject right)
            => new ArrayOrObject<TElement, TObject>(right);

        public ArrayOrObject()
        {
        }

        public ArrayOrObject(TElement[] left) : base(left)
        {
        }

        public ArrayOrObject(TObject right) : base(right)
        {
        }

        protected override EitherTag OnDeserializing(JsonDataType jsonType)
        {
            return
                (jsonType == JsonDataType.Array) ? EitherTag.Left :
                (jsonType == JsonDataType.Object) ? EitherTag.Right :
                EitherTag.None;
        }
    }
}
