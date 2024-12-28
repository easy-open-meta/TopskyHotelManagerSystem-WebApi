namespace EOM.TSHotelManager.Shared
{
    public class JwtConfig
    {
        public string Key { get; set; } // 对应配置中的 Jwt:Key
        public string Issuer { get; set; } // 对应配置中的 Jwt:Issuer
        public string Audience { get; set; } // 对应配置中的 Jwt:Audience
        public int ExpiryMinutes { get; set; } // 对应配置中的 Jwt:ExpiryMinutes
    }
}
