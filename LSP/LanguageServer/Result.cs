using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer
{
    internal enum ResultTag
    {
        Success = 1,
        Error = 2,
    }

    public class Result<T, TError>
    {
        private readonly ResultTag _tag;
        private readonly T _success;
        private readonly TError _error;

        public Result(T result)
        {
            _tag = ResultTag.Success;
            _success = result;
            _error = default(TError);
        }

        public Result(TError error)
        {
            _tag = ResultTag.Error;
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
                (!successIsDefault && errorIsDefault) ? ResultTag.Success :
                (successIsDefault && errorIsDefault) ? ResultTag.Success :
                default(ResultTag);
            _success = success;
            _error = error;
        }

        public T Success { get => _success; }
        public TError Error { get => _error; }
        public bool IsSuccess { get => _tag == ResultTag.Success; }
        public bool IsError { get => _tag == ResultTag.Error; }

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

    public class VoidResult<TError>
    {
        private readonly ResultTag _tag;
        private readonly TError _error;

        public VoidResult(TError error)
        {
            var errorIsDefault = EqualityComparer<TError>.Default.Equals(error, default(TError));
            if (!errorIsDefault)
            {
                _tag = ResultTag.Success;
            }
            else
            {
                _tag = ResultTag.Error;
                _error = error;
            }
        }

        public TError Error { get => _error; }
        public bool IsSuccess { get => _tag == ResultTag.Success; }
        public bool IsError { get => _tag == ResultTag.Error; }

        public static implicit operator VoidResult<TError>(TError error) => new VoidResult<TError>(error);

        public Result<TResult, TError> Select<TResult>(Func<TResult> func) =>
            this.IsSuccess
                ? new Result<TResult, TError>(func())
                : new Result<TResult, TError>(this.Error);

        public Result<TResult, TErrorResult> Select<TResult, TErrorResult>(Func<TResult> funcSuccess, Func<TError, TErrorResult> funcError) =>
            this.IsSuccess ? new Result<TResult, TErrorResult>(funcSuccess()) :
            this.IsError ? new Result<TResult, TErrorResult>(funcError(this.Error)) :
            default(Result<TResult, TErrorResult>);

        public TResult Handle<TResult>(Func<TResult> funcSuccess, Func<TError, TResult> funcError) =>
            this.IsSuccess ? funcSuccess() :
            this.IsError ? funcError(this.Error) :
            default(TResult);

        public void Handle(Action actionSuccess, Action<TError> actionError)
        {
            if (this.IsSuccess)
            {
                actionSuccess();
            }
            else if (this.IsError)
            {
                actionError(this.Error);
            }
        }

        public void HandleError(Action<TError> actionError)
        {
            if (this.IsError) actionError(this.Error);
        }
    }
}
