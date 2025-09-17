namespace Application.Features.Users.Command.Register;

public record RegisterCommand(string Email, string Password, string ConfirmPassword, string UserName,IFormFile Avatar);