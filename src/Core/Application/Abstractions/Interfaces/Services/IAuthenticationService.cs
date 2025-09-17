namespace Application.Abstractions.Interfaces.Services;


public interface IAuthenticationService {
    Task<Result<AuthDto>> RegisterAsync(RegisterRequest request);
    Task<Result<AuthDto>> GetTokenAsync(TokenRequest request);
}