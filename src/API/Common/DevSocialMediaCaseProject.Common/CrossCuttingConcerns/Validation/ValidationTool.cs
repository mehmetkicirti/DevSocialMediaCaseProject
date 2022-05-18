using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Common.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public async static Task ValidateAsync(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var results = await validator.ValidateAsync(context);
            if (!results.IsValid)
                throw new ValidationException(results.Errors);
        } 
    }
}
