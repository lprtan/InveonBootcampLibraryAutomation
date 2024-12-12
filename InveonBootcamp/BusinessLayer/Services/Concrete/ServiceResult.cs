using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class ServiceResult
    {
        public int StatusCode { get; set; }
        public ProblemDetails? ErrorDetails { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public static ServiceResult<T> Success(T data, int statusCode)
        {
            return new ServiceResult<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }

        public static ServiceResult<T> Fail(string message, int statusCode)
        {
            return new ServiceResult<T>
            {
                StatusCode = statusCode,
                ErrorDetails = new ProblemDetails
                {
                    Detail = message,
                    Status = statusCode
                }
            };
        }
    }
}
