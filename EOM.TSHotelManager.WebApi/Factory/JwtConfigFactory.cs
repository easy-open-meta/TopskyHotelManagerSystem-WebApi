using EOM.TSHotelManager.Shared;
using Microsoft.Extensions.Configuration;

namespace EOM.TSHotelManager.WebApi
{
    public class JwtConfigFactory : IJwtConfigFactory
    {
        private readonly IConfiguration _configuration;

        public JwtConfigFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtConfig GetJwtConfig()
        {
            var jwtConfig = new JwtConfig
            {
                Key = _configuration["Jwt:Key"],
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                ExpiryMinutes = int.Parse(_configuration["Jwt:ExpiryMinutes"])
            };
            return jwtConfig;
        }
    }
}
