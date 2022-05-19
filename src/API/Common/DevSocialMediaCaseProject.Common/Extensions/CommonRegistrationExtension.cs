using DevSocialMediaCaseProject.Common.Configurations.MongoDB;
using DevSocialMediaCaseProject.Common.Utilities.Security.Encryption;
using DevSocialMediaCaseProject.Common.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Extensions
{
    public static class CommonRegistrationExtension
    {
        public static void AddCommonServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITokenHelper, TokenHelper>();
            services.Configure<MongoDBSetting>(opt =>
            {
                opt.ConnectionURL = configuration.GetSection("MongoDBConnection:ConnectionURL").Value;
                opt.DatabaseName = configuration.GetSection("MongoDBConnection:DatabaseName").Value;
            });
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = CredentialsHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
        }
    }
}
