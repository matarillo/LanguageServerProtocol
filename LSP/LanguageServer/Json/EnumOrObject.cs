using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public sealed class EnumOrObject<T1, T2> : INumberOrObject
        where T1 : struct, IConvertible
        where T2 : class
    {
        private T1? _enum;
        private T2 _object;

        public static implicit operator EnumOrObject<T1, T2>(T1 value) => new EnumOrObject<T1, T2>(value);
        public static implicit operator EnumOrObject<T1, T2>(T2 value) => new EnumOrObject<T1, T2>(value);

        // for deserializer
        private EnumOrObject()
        {
        }

        public EnumOrObject(T1 value)
        {
            _enum = value;
        }

        public EnumOrObject(T2 value)
        {
            _object = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool IsEnum { get => _enum.HasValue; }

        public bool IsObject { get => _object != null; }

        public T1 Enum { get => _enum ?? throw new InvalidOperationException(); }

        public T2 Object { get => _object ?? throw new InvalidOperationException(); }

        public override string ToString() =>
            _enum.HasValue ? _enum.Value.ToString() :
            _object != null ? _object.ToString() :
            "null";

        bool INumberOrObject.IsNumber { get => IsEnum; }

        long INumberOrObject.Number
        {
            get => this.Enum.ToInt64(null);
            set
            {
                _enum = (T1)System.Enum.ToObject(typeof(T1), value);
                _object = null;
            }
        }

        object INumberOrObject.Object
        {
            get => this.Object;
            set
            {
                _enum = null;
                _object = (T2)value;
            }
        }

        Type INumberOrObject.ObjectType
        {
            get => typeof(T2);
        }
    }
}
