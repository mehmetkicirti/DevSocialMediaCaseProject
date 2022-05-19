using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public class ErrorResponse: IErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }


        public ErrorResponse(string message):this(false)
        {
            Message = message;
        }
        public ErrorResponse(string message, int statusCode): this(message)
        {
            StatusCode = statusCode;
        }

        public ErrorResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
