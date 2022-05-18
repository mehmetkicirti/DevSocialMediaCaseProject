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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
