using Login.Core.DTO;
using Login.Core.Entities;
using Login.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IJwtService> _logger;

        public JwtService(IConfiguration configutaion, ILogger<IJwtService> logger)
        {
            _configuration = configutaion;
            _logger = logger;
        }
        public AuthenticationResponse CreateJwtToken(User user)
        {
            try
            {
                DateTime? expiration = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));

                Claim[] authclaims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now),
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim(ClaimTypes.Name, user.UserName)
            };

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken tokenGenerator = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims: authclaims,
                    expires: expiration,
                    signingCredentials: signingCredentials
                    );

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                string token = handler.WriteToken(tokenGenerator);

                return new AuthenticationResponse() { Token = token, PersonName = user.UserName, Expiration = expiration };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return new AuthenticationResponse();
        }
    }
}
