using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Utilities.Interceptors
{
    /// <summary>
    /// This class executes method or class by taking type Attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptorBaseAttribute : Attribute, IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
