using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Exceptions
{
    public class DatabaseException : Exception
    {
        public int StatusCode { get; set; }
        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, int statusCode) : this(message)
        {
            StatusCode = statusCode;
        }

        public DatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
