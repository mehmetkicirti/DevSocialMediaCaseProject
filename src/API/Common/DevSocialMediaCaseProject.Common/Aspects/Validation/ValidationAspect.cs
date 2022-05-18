using Castle.DynamicProxy;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.CrossCuttingConcerns.Validation;
using DevSocialMediaCaseProject.Common.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Aspects.Validation
{
    public class ValidationAspect : MethodInterceptor
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(ExceptionConstants.VALIDATION_TYPE_ERROR);
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // for ex. => AbstractValidator<Blog> => Blog generic Arguments of first item
            var entities = invocation.Arguments.Where(arg => arg.GetType() == entityType); // It is getting equal to given type while sending request.

            foreach (var entity in entities)
            {
                ValidationTool.ValidateAsync(validator, entity).GetAwaiter().GetResult();
            }
        }
    }
}
