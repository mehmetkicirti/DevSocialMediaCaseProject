using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public interface IDataResponse<T>: IResponse
    {
        T Data { get; set; }
    }
}
