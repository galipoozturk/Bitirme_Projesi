using Microsoft.IdentityModel.Tokens;
using NTierSample.BLL.Abstract;
using NTierSample.Model.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTierSample.BLL.Concrete
{
    public class TokenService : ITokenService
    {
        private const double EXPIRY_DURATION_MINUTES = 30;
        public string BuildToken(User user)
        {
            var claims = new[] {
            new Claim("email", user.Email),
            new Claim("user_id", user.ID.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Email)
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("test12531251254612545126565365162537512536512765371523127231231"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken("localhost", "localhost", claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("test12531251254612545126565365162537512536512765371523127231231")),
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
