using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Utilities.Security.Encryption
{
    public class CredentialsHelper
    {
        /// <summary>
        /// It is provided by application.json into SecurityKey. It creates Security Key for JWT 
        /// </summary>
        /// <returns></returns>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
        /// <summary>
        /// It creates encrypted signingcredentials object by securityKey.
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
