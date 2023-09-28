namespace BufferDinner.Infrastructure.Authentication;

public class jwtSettings
{
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; } 
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}