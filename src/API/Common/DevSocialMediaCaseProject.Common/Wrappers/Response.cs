using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public class Response : IResponse
    {
        public Response(string message, bool isSuccess):this(isSuccess)
        {
            Message = message;
        }
        public Response(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
