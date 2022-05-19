using DevSocialMediaCaseProject.Common.Configurations.MongoDB;
using DevSocialMediaCaseProject.Common.Utilities.Security.Encryption;
using DevSocialMediaCaseProject.Common.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "API Swagger",
                    Description = "Api Swagger Documentation",
                    TermsOfService = new Uri("http://swagger.io/terms/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mehmet Aydın KICIRTI",
                        Email = "mehmetkicirti@hotmail.com",
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYyODU5NTY3MWMxNzljZGM1MDdhZWM5YSIsImVtYWlsIjoibWVobWV0a2ljaXJ0aUBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTWVobWV0ICRLSUNJUlRJIiwibmJmIjoxNjUyOTMxMDQzLCJleHAiOjE2NTI5MzE5NDMsImlzcyI6Ii9udHRkYXRhdGVzdGNhc2UiLCJhdWQiOiIvbnR0ZGF0YXRlc3RjYXNlIn0.8rC35jEQNh0FL9fFTXtJV4EKJkd0ei6A2v_S2xMDsz0\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}
