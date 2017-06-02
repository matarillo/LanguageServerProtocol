using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Json
{
    public sealed class NumberOrString : Either<long, string>, IEquatable<NumberOrString>
    {
        public static implicit operator NumberOrString(long left) => new NumberOrString(left);

        public static implicit operator NumberOrString(string right) => new NumberOrString(right);

        public NumberOrString()
        {
        }

        public NumberOrString(long left) : base(left)
        {
        }

        public NumberOrString(string right) : base(right)
        {
        }

        protected override EitherTag OnDeserializing(JsonDataType jsonType)
        {
            return
                (jsonType == JsonDataType.Number) ? EitherTag.Left :
                (jsonType == JsonDataType.String) ? EitherTag.Right :
                EitherTag.None;
        }

        public override int GetHashCode() =>
            IsLeft ? Left.GetHashCode() :
            IsRight ? Right.GetHashCode() :
            0;

        public override bool Equals(object obj)
        {
            var other = obj as NumberOrString;
            return (other == null) ? false : Equals(other);
        }

        public bool Equals(NumberOrString other) =>
            (IsLeft && other.IsLeft) ? (Left == other.Left) :
            (IsRight && other.IsRight) ? (Right == other.Right) :
            (!IsLeft && !IsRight && !other.IsLeft && !other.IsRight); // None == None
    }
}
