using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigurateCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
