namespace Application.Request.Auth;

public record RegisterRequest(string Email, string Password, string ConfirmPassword, string UserName,IFormFile Avatar);