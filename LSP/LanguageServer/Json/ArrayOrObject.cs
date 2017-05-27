using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Json
{
    public sealed class ArrayOrObject<TElement, T> : IArrayOrObject
        where TElement : class
        where T : class
    {
        private TElement[] _array;
        private T _object;

        // for deserializer
        private ArrayOrObject()
        {
        }

        public ArrayOrObject(TElement[] value)
        {
            _array = value;
        }

        public ArrayOrObject(T value)
        {
            _object = value;
        }

        public static implicit operator ArrayOrObject<TElement, T>(TElement[] value) => new ArrayOrObject<TElement, T>(value);
        public static implicit operator ArrayOrObject<TElement, T>(T value) => new ArrayOrObject<TElement, T>(value);

        public bool IsArray { get => _array != null; }

        public bool IsObject { get => _object != null; }

        public TElement[] Array { get => _array ?? throw new InvalidOperationException(); }

        public T Object { get => _object ?? throw new InvalidOperationException(); }

        object[] IArrayOrObject.Array
        {
            get => this.Array;
            set
            {
                _array = (TElement[])value;
                _object = null;
            }
        }

        object IArrayOrObject.Object
        {
            get => this.Object;
            set => throw new NotImplementedException();
        }

        Type IArrayOrObject.ArrayElementType => typeof(TElement);

        Type IArrayOrObject.ObjectType => typeof(T);

        public override string ToString() =>
            _array != null ? "[" + string.Join(",", (IEnumerable<TElement>)_array) + "]" :
            _object != null ? _object.ToString() :
            "null";
    }
}
