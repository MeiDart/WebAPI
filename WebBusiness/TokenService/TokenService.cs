using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebCommon.Constants;
using WebModels.Entities;

namespace WebBusiness.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserAccount user)
        {
            var newToken = new JwtSecurityTokenHandler();
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetConnectionString(Constants.AppSettingKeys.JWT_SECRET)));
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration[Constants.AppSettingKeys.JWT_SECRET]);
            //var credentials = new SigningCredentials(secretKeyBytes, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(_configuration.GetConnectionString(Constants.AppSettingKeys.JWT_VALIDISSUER),
            //  _configuration.GetConnectionString(Constants.AppSettingKeys.JWT_VALIDISSUER),
            //  new ClaimsIdentity(new[] {
            //  new Claim(ClaimTypes.Name, user.HoTen),
            //  new Claim(ClaimTypes.Email, user.Email),
            //  }), 
            //  expires: DateTime.Now.AddMinutes(120),
            //  signingCredentials: credentials);


            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user?.UserName),
                    new Claim(ClaimTypes.Sid, user?.Id),
                    user?.Email != null ? new Claim(JwtRegisteredClaimNames.Email, user?.Email) : null,
                    user?.Email != null ? new Claim(JwtRegisteredClaimNames.Sub, user?.Email) : null,
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", user?.UserName),
                    new Claim("Id", user?.Id.ToString()),
                    //roles
                }),
                Expires = DateTime.Now.AddMinutes(double.Parse(_configuration[Constants.AppSettingKeys.JWT_EXPIREMINUTES])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = newToken.CreateToken(tokenDescription);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
