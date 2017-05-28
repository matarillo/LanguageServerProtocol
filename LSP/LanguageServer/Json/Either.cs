using System;
using System.Linq;
using System.Reflection;

namespace LanguageServer.Json
{
    public abstract class Either<TLeft, TRight> : IEither
    {
        private EitherTag _tag;
        private TLeft _left;
        private TRight _right;

        public Either()
        {
        }

        public Either(TLeft left)
        {
            _tag = EitherTag.Left;
            _left = left;
        }

        public Either(TRight right)
        {
            _tag = EitherTag.Right;
            _right = right;
        }

        public bool IsLeft => _tag == EitherTag.Left;

        public bool IsRight => _tag == EitherTag.Right;

        public TLeft Left => _tag == EitherTag.Left ? _left : throw new InvalidOperationException();

        public TRight Right => _tag == EitherTag.Right ? _right : throw new InvalidOperationException();

        public Type LeftType => typeof(TLeft);

        public Type RightType => typeof(TRight);

        protected abstract EitherTag OnDeserializing(JsonDataType jsonType);

        object IEither.Left
        {
            get => this.Left;
            set
            {
                _tag = EitherTag.Left;
                _left = (TLeft)value;
                _right = default(TRight);
            }
        }

        object IEither.Right
        {
            get => this.Right;
            set
            {
                _tag = EitherTag.Right;
                _left = default(TLeft);
                _right = (TRight)value;
            }
        }

        EitherTag IEither.OnDeserializing(JsonDataType jsonType) => this.OnDeserializing(jsonType);
    }
}
