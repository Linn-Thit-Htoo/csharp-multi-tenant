using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csharp.multitenant.Models.Features
{
    public class Result<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

        public static Result<T> SuccessResult(string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Message = message,
                StatusCode = statusCode,
                Data = default
            };
        }

        public static Result<T> SuccessResult(T data, string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new Result<T>
            {
                IsSuccess = true,
                StatusCode = statusCode,
                Message = message,
                Data = data
            };
        }

        public static Result<T> FailureResult(string message = "Fail", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new Result<T>
            {
                Data = default,
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
