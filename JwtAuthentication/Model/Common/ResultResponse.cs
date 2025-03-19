using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Model.Common;

public class ResultResponse<T>
{
    public bool IsSuccess { get; private set; }
    public T Data { get; private set; }
    public string Message { get; private set; }

    private ResultResponse(bool isSuccess, T data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public static ResultResponse<T> Success(T data, string message = null)
    {
        return new ResultResponse<T>(true, data, message);
    }

    public static ResultResponse<T> Failure(string message, T data = default)
    {
        return new ResultResponse<T>(false, data, message);
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
