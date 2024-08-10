using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<string> GenerateAsync(User user)
        {



            var claims = new[] {
                  new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                  new Claim("Id" , user.Id.ToString()),
                  new Claim("UserName" , user.UserName.ToString()),
                  new Claim("PassWord" , user.PassWord.ToString()),

                 };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        _config["JwtSettings:Issuer"],
                        _config["JwtSettings:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<string> GenerateAsync2(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
              _config["JwtSettings:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }

    }
}
