using System;

namespace LanguageServer.Json
{
    public sealed class NumberOrString : Either, IEquatable<NumberOrString>
    {
        public static implicit operator NumberOrString(long value) => new NumberOrString(value);

        public static implicit operator NumberOrString(string value) => new NumberOrString(value);

        public NumberOrString(long value)
        {
            Type = typeof(long);
            Value = value;
        }

        public NumberOrString(string value)
        {
            Type = typeof(string);
            Value = value;
        }

        public bool IsLeft => Type == typeof(long);

        public bool IsRight => Type == typeof(string);

        public long Left => GetValue<long>();

        public string Right => GetValue<string>();

        public override int GetHashCode() =>
            IsLeft ? Left.GetHashCode() :
            IsRight ? Right.GetHashCode() :
            0;

        public override bool Equals(object obj)
        {
            return (obj is NumberOrString other) && Equals(other);
        }

        public bool Equals(NumberOrString other) =>
            (IsLeft && other.IsLeft) ? (Left == other.Left) :
            (IsRight && other.IsRight) ? (Right == other.Right) :
            (!IsLeft && !IsRight && !other.IsLeft && !other.IsRight); // None == None
    }
}
