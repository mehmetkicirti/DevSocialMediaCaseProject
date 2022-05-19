using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Wrappers
{
    public class ServiceDataResponse<T> : Response, IDataResponse<T>
    {
        public ServiceDataResponse(T data, bool isSuccess):base(isSuccess)
        {
            Data = data;
        }

        public ServiceDataResponse(T data) : base(true)
        {
            Data = data;
        }

        public ServiceDataResponse(T data, bool isSuccess, string message) : base(message, isSuccess)
        {
            Data = data;
        }

        public ServiceDataResponse(T data, string message) : base(message, true)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
