﻿namespace Intelligent_Career_Advisor.Abstractions;

public class Result
{

    public Result(bool isSuccess, Error error)
    {   
        if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            throw new InvalidOperationException("Invalid result state");
        this.IsSuccess = isSuccess;
        this.Error = error;
    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; } = default!;

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);
    public static Result<T> Failure<T>(Error error) => new(default!, false, error);

}

public class Result<T> : Result
{
    public readonly T _value;
    public Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public T Value => IsSuccess ? _value : throw new InvalidOperationException("Result is not successful");
}
