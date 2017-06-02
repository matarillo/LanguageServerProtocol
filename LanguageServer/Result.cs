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
        public static Result<T, TError> Success(T success)
        {
            return new Result<T, TError>(ResultTag.Success, success, default(TError));
        }

        public static Result<T, TError> Error(TError error)
        {
            return new Result<T, TError>(ResultTag.Error, default(T), error);
        }

        private readonly ResultTag _tag;
        private readonly T _success;
        private readonly TError _error;

        private Result(ResultTag tag, T success, TError error)
        {
            _tag = tag;
            _success = success;
            _error = error;
        }

        public T SuccessValue { get => _success; }
        public TError ErrorValue { get => _error; }
        public bool IsSuccess { get => _tag == ResultTag.Success; }
        public bool IsError { get => _tag == ResultTag.Error; }

        public Result<TResult, TError> Select<TResult>(Func<T, TResult> func) =>
            this.IsSuccess
                ? Result<TResult, TError>.Success(func(this.SuccessValue))
                : Result<TResult, TError>.Error(this.ErrorValue);

        public Result<TResult, TErrorResult> Select<TResult, TErrorResult>(Func<T, TResult> funcSuccess, Func<TError, TErrorResult> funcError) =>
            this.IsSuccess ? Result<TResult, TErrorResult>.Success(funcSuccess(this.SuccessValue)) :
            this.IsError ? Result<TResult, TErrorResult>.Error(funcError(this.ErrorValue)) :
            default(Result<TResult, TErrorResult>);

        public TResult Handle<TResult>(Func<T, TResult> funcSuccess, Func<TError, TResult> funcError) =>
            this.IsSuccess ? funcSuccess(this.SuccessValue) :
            this.IsError ? funcError(this.ErrorValue) :
            default(TResult);

        public void Handle(Action<T> actionSuccess, Action<TError> actionError)
        {
            if (this.IsSuccess)
            {
                actionSuccess(this.SuccessValue);
            }
            else if (this.IsError)
            {
                actionError(this.ErrorValue);
            }
        }

        public T HandleError(Func<TError, T> func) =>
            this.IsError
                ? func(this.ErrorValue)
                : this.SuccessValue;
    }

    public class VoidResult<TError>
    {
        public static VoidResult<TError> Success()
        {
            return new VoidResult<TError>(ResultTag.Success, default(TError));
        }

        public static VoidResult<TError> Error(TError error)
        {
            return new VoidResult<TError>(ResultTag.Error, error);
        }

        private readonly ResultTag _tag;
        private readonly TError _error;

        private VoidResult(ResultTag tag, TError error)
        {
            _tag = tag;
            _error = error;
        }

        public TError ErrorValue { get => _error; }
        public bool IsSuccess { get => _tag == ResultTag.Success; }
        public bool IsError { get => _tag == ResultTag.Error; }

        public Result<TResult, TError> Select<TResult>(Func<TResult> func) =>
            this.IsSuccess
                ? Result<TResult, TError>.Success(func())
                : Result<TResult, TError>.Error(this.ErrorValue);

        public Result<TResult, TErrorResult> Select<TResult, TErrorResult>(Func<TResult> funcSuccess, Func<TError, TErrorResult> funcError) =>
            this.IsSuccess ? Result<TResult, TErrorResult>.Success(funcSuccess()) :
            this.IsError ? Result<TResult, TErrorResult>.Error(funcError(this.ErrorValue)) :
            default(Result<TResult, TErrorResult>);

        public TResult Handle<TResult>(Func<TResult> funcSuccess, Func<TError, TResult> funcError) =>
            this.IsSuccess ? funcSuccess() :
            this.IsError ? funcError(this.ErrorValue) :
            default(TResult);

        public void Handle(Action actionSuccess, Action<TError> actionError)
        {
            if (this.IsSuccess)
            {
                actionSuccess();
            }
            else if (this.IsError)
            {
                actionError(this.ErrorValue);
            }
        }

        public void HandleError(Action<TError> actionError)
        {
            if (this.IsError) actionError(this.ErrorValue);
        }
    }
}
