namespace Infrastructure.Identity.Helper;

public record Jwt(string Key, string Issuer, string Audience, double DurationInDays);