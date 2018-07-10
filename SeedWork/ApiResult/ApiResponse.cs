using System;
using System.Collections.Generic;
using System.Text;

namespace YYY.Microservices.Domain.SeedWork
{
    [Serializable]
    public class ApiResponse : ApiResponse<object>
    {
        public ApiResponse() { }
        public ApiResponse(bool success)
            : base(success) { }
        public ApiResponse(object result)
            : base(result) { }
        public ApiResponse(ErrorInfo error, bool unAuthorizedRequest = false)
            : base(error, unAuthorizedRequest) { }
    }
    [Serializable]
    public class ApiResponse<TResult>
    {
        public TResult Result { get; set; }
        public bool Success { get; set; }
        public ErrorInfo Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }

        public ApiResponse()
        {
            Success = true;
        }

        public ApiResponse(bool success)
        {
            Success = success;
        }

        public ApiResponse(TResult result)
        {
            Result = result;
            Success = true;
        }

        public ApiResponse(ErrorInfo error, bool unAuthorizedRequest = false)
        {
            Error = error;
            UnAuthorizedRequest = unAuthorizedRequest;
            Success = false;
        }
    }
}
