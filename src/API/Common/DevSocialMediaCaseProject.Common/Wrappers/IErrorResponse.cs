using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public interface IErrorResponse: IResponse
    {
        int StatusCode { get; set; }
    }
}
