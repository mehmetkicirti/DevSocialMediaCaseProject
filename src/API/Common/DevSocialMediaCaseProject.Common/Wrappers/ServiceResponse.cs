using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public class ServiceResponse : Response, IResponse
    {
        public ServiceResponse() : base(true)
        {
        }
        public ServiceResponse(string message, bool isSuccess) : base(message, isSuccess)
        {
        }
        public ServiceResponse(string message) : base(message, true)
        {
        }
    }
}
