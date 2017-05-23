using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public interface INumberOrObject
    {
        bool IsNumber { get; }
        bool IsObject { get; }
        long NumberValue { get; }
        object ObjectValue { get; }
    }

    public sealed class NumberOrObject<T> : INumberOrObject
        where T : class
    {
        private readonly long? _numberValue;
        private readonly T _objectValue;

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

        public long NumberValue
        {
            get =>
                _numberValue.HasValue ? _numberValue.Value :
                throw new InvalidOperationException();
        }

        public T ObjectValue
        {
            get =>
                _objectValue != null ? _objectValue :
                throw new InvalidOperationException();
        }

        public override string ToString() =>
            _numberValue.HasValue ? _numberValue.Value.ToString() :
            _objectValue != null ? _objectValue.ToString() :
            "null";

        object INumberOrObject.ObjectValue
        {
            get => this.ObjectValue;
        }
    }
}
