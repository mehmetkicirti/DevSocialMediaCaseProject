using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public interface IResponse
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }

    }
}
