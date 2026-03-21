namespace AuthSample.Backend.JWT;

public class JwtSettings
{
    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int AccessTokenExpirationMinutes { get; set; } = 10;
    public int RefreshTokenExpirationDays { get; set; } = 7;
}