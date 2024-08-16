using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NadinTest.Core.JWT;
using NadinTest.Core.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NadinTest.Service.Services
{
    public class JwtService : IJwtService
    {
        private IConfiguration _config;

        public JwtService(IConfiguration _config)
        {

            this._config = _config;
        }

        public async Task<AccessToken> GenerateAsync(User user)
        {
            var claims = new[] {
                  new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                  new Claim("Id" , user.Id.ToString()),
                  new Claim("UserName" , user.UserName.ToString()),
                  new Claim("PassWord" , user.PassWord.ToString()),
            };


            var secretKey = Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);



            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                Expires = DateTime.Now.AddMinutes(600),
                SigningCredentials = signingCredentials,

                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);

            return new AccessToken(securityToken);
        }

    }
}
