using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Utilities.Interceptors
{
    /// <summary>
    /// This class executes which chosen methods by given aspects. 
    /// </summary>
    public class MethodInterceptor: MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        //invocation : called as method.  
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch(Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }
        }
    }
}
