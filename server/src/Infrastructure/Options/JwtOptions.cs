namespace Infrastructure.Options
{
    public class JwtOptions
    {
        public const string JWT = "Jwt";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInSeconds { get; set; }
        public string SigningKey { get; set; }
    }
}