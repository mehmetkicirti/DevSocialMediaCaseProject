using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Constants
{
    public class ExceptionConstants
    {
        public const string OBJECT_IS_NULL = "Related object is null.";
        public const string VALIDATION_TYPE_ERROR = "It is not assignable for IValidator type class.";
        public const string UNAUTHORIZE_ERROR = "UnAuthorized Error. This request can not be accessible for you.";
        public const string USER_EXIST_ERROR = "User already exists. Please try another email address.";
        public const string USER_NOT_EXIST_ERROR = "User not exists. Please try another email address.";
        public const string PASSWORD_NOT_MATCHED_ERROR = "Maybe your password is not true. Try again with truth password.";
    }
}
