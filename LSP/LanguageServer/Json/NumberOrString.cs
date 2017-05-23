using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Json
{
    public sealed class NumberOrString : IEquatable<NumberOrString>
    {
        private readonly long? _numberValue;
        private readonly string _stringValue;

        public NumberOrString(long value)
        {
            _numberValue = value;
        }

        public NumberOrString(string value)
        {
            _stringValue = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsNumber { get => _numberValue.HasValue; }

        public bool IsString { get => _stringValue != null; }

        public long NumberValue
        {
            get =>
                _numberValue.HasValue ? _numberValue.Value :
                throw new InvalidOperationException();
        }

        public string StringValue
        {
            get =>
                _numberValue.HasValue ? _numberValue.Value.ToString() :
                _stringValue != null ? _stringValue :
                throw new InvalidOperationException();
        }

        public override int GetHashCode() =>
            _numberValue.HasValue ? _numberValue.Value.GetHashCode() :
            _stringValue != null ? _stringValue.GetHashCode() :
            0;

        public override bool Equals(object obj)
        {
            var other = obj as NumberOrString;
            return (other == null) ? false : Equals(other);
        }

        public bool Equals(NumberOrString other) =>
            _numberValue.HasValue ? (_numberValue == other._numberValue) :
            _stringValue != null ? (_stringValue == other._stringValue) :
            (null == other._stringValue);

        public string ToJsonValue() =>
            _numberValue.HasValue ? _numberValue.Value.ToString() :
            _stringValue != null ? "\"" + _stringValue + "\"" :
            "null";

        public override string ToString()
        {
            return ToJsonValue();
        }

        public static implicit operator NumberOrString(long value) => new NumberOrString(value);
        public static implicit operator NumberOrString(string value) => new NumberOrString(value);
    }
}
