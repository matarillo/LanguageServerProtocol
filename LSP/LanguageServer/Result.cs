using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer
{
    public struct Result<T, TError>
    {
        private const int TagSuccess = 1;
        private const int TagError = 2;
        private readonly int _tag;
        private readonly T _success;
        private readonly TError _error;

        public Result(T result)
        {
            _tag = TagSuccess;
            _success = result;
            _error = default(TError);
        }

        public Result(TError error)
        {
            _tag = TagError;
            _success = default(T);
            _error = error;
        }

        public Result(T success, TError error)
        {
            var successIsDefault = EqualityComparer<T>.Default.Equals(success, default(T));
            var errorIsDefault = EqualityComparer<TError>.Default.Equals(error, default(TError));

            if (!successIsDefault && !errorIsDefault)
            {
                throw new ArgumentException();
            }
            _tag =
                (!successIsDefault && errorIsDefault) ? TagSuccess :
                (successIsDefault && errorIsDefault) ? TagError :
                default(int);
            _success = success;
            _error = error;
        }

        public T Success { get => _success; }
        public TError Error { get => _error; }
        public bool IsSuccess { get => _tag == TagSuccess; }
        public bool IsError { get => _tag == TagError; }

        public static implicit operator Result<T, TError>(T success) => new Result<T, TError>(success);
        public static implicit operator Result<T, TError>(TError error) => new Result<T, TError>(error);

        public Result<TResult, TError> Select<TResult>(Func<T, TResult> func) =>
            this.IsSuccess
                ? new Result<TResult, TError>(func(this.Success))
                : new Result<TResult, TError>(this.Error);

        public Result<TResult, TErrorResult> Select<TResult, TErrorResult>(Func<T, TResult> funcSuccess, Func<TError, TErrorResult> funcError) =>
            this.IsSuccess ? new Result<TResult, TErrorResult>(funcSuccess(this.Success)) :
            this.IsError ? new Result<TResult, TErrorResult>(funcError(this.Error)) :
            default(Result<TResult, TErrorResult>);

        public TResult Handle<TResult>(Func<T, TResult> funcSuccess, Func<TError, TResult> funcError) =>
            this.IsSuccess ? funcSuccess(this.Success) :
            this.IsError ? funcError(this.Error) :
            default(TResult);

        public void Handle(Action<T> actionSuccess, Action<TError> actionError)
        {
            if (this.IsSuccess)
            {
                actionSuccess(this.Success);
            }
            else if (this.IsError)
            {
                actionError(this.Error);
            }
        }

        public T HandleError(Func<TError, T> func) =>
            this.IsError
                ? func(this.Error)
                : this.Success;
    }
}
