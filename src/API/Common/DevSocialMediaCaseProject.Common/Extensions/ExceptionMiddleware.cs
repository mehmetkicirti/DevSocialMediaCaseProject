using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Wrappers;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Common.Extensions
{
    public class ExceptionMiddleware
    {
        private const string ContentType = "application/json";
        private const string ErrorMessage = "Internal Server Error";

        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = ContentType;

            string errorMessage = ErrorMessage;
            int statusCode = (int)HttpStatusCode.InternalServerError;

            if (ex is DatabaseException || ex is ValidationException)
            {
                errorMessage = ex.Message;
                statusCode = (int)HttpStatusCode.BadRequest;
            }

            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(
                new ErrorResponse(errorMessage, statusCode).ToString()
                );
        }
    }
}
