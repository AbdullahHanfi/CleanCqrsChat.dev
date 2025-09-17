namespace Application.DTOs.Auth;

public record AuthDto (string UserName, string Email, string Token, DateTime ExpiresOn, bool IsAuthenticated = false);