using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Encrytion;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenOption
    {
        IConfiguration Configuration;
        TokenOption tokenOption;
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOption = Configuration.GetSection("TokenOptions").Get<TokenOption>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(tokenOption.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaim)
        {
            //Microsoft.Identity.Token paketini dahil et
            var securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOption.SecurityKey);
            var signingCredential = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(tokenOption,user,signingCredential,operationClaim);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOption tokenOption,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            JwtSecurityToken jwt = new JwtSecurityToken
                (

                audience:tokenOption.Audience,
                issuer:tokenOption.Issuer,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials,
                claims:SetClaim(user,operationClaims)
                );
            return jwt;
        }

        public IEnumerable<Claim> SetClaim(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddName(user.FirstName);
            claims.AddLastName(user.LastName);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddRoles(operationClaims.Select(c=>c.ClaimName).ToArray());
            return claims;
        }
    }
}
