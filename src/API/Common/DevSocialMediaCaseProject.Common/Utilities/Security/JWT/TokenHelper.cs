using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Common.Extensions;
using DevSocialMediaCaseProject.Common.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Utilities.Security.JWT
{
    public class TokenHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public TokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken(User user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = CredentialsHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = CredentialsHelper.CreateSigningCredentials(securityKey);

            var securityToken = CreateSecurityToken(_tokenOptions, user, signingCredentials);

            // Create Token by SecurityToken Options
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(securityToken);

            return new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token
            };
        }

        public JwtSecurityToken CreateSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials) => new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                claims: SetClaims(user),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );
        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name} ${user.Surname}");
            return claims;
        } 

    }
}
