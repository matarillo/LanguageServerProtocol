using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public sealed class NumberOrObject<T> : INumberOrObject
        where T : class
    {
        private long? _numberValue;
        private T _objectValue;

        public static implicit operator NumberOrObject<T>(long value) => new NumberOrObject<T>(value);
        public static implicit operator NumberOrObject<T>(T value) => new NumberOrObject<T>(value);

        // for deserializer
        private NumberOrObject()
        {
        }

        public NumberOrObject(long value)
        {
            _numberValue = value;
        }

        public NumberOrObject(T value)
        {
            _objectValue = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsNumber { get => _numberValue.HasValue; }

        public bool IsObject { get => _objectValue != null; }

        public long Number { get => _numberValue ?? throw new InvalidOperationException(); }

        public T Object { get => _objectValue ?? throw new InvalidOperationException(); }

        public override string ToString() =>
            _numberValue.HasValue ? _numberValue.Value.ToString() :
            _objectValue != null ? _objectValue.ToString() :
            "null";

        long INumberOrObject.Number
        {
            get => this.Number;
            set
            {
                _numberValue = value;
                _objectValue = null;
            }
        }

        object INumberOrObject.Object
        {
            get => this.Object;
            set
            {
                _numberValue = null;
                _objectValue = (T)value;
            }
        }

        Type INumberOrObject.ObjectType
        {
            get => typeof(T);
        }
    }
}
