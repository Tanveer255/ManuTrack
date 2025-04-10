using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T Data { get; private set; }
    public string Message { get; private set; }

    private Result(bool isSuccess, T data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public static Result<T> Success(T data, string message = null)
    {
        return new Result<T>(true, data, message);
    }

    public static Result<T> Failure(string message, T data = default)
    {
        return new Result<T>(false, data, message);
    }

    // Optional: Add methods to check for success/failure
    public bool Succeeded()
    {
        return IsSuccess;
    }

    public bool Failed()
    {
        return !IsSuccess;
    }
}
