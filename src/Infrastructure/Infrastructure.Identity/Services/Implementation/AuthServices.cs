namespace Infrastructure.Identity.Services.Implementation;

internal class AuthenticationService(UserManager<ApplicationUser> userManager, IOptions<Jwt> jwt) : IAuthenticationService {
    private readonly Jwt _jwt = jwt.Value;
    public async Task<Result<AuthDto>> RegisterAsync(RegisterRequest model) {
        if (await userManager.FindByEmailAsync(model.Email) is not null)
            return Result.Failure<AuthDto>(new("Email is already registered!"));

        if (await userManager.FindByNameAsync(model.UserName) is not null)
            return Result.Failure<AuthDto>(new("Username is already registered!"));

        var user = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,

        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded){
            var errors = string.Empty;

            foreach (var error in result.Errors)
                errors += $"{error.Description},";

            return Result.Failure<AuthDto>(new(errors));
        }

        await userManager.AddToRoleAsync(user, "User");

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthDto(user.UserName, user.Email, new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, true);
    }

    public async Task<Result<AuthDto>> GetTokenAsync(TokenRequest model) {

        var user = await userManager.FindByEmailAsync(model.Email);
    
        if (user is null || !await userManager.CheckPasswordAsync(user, model.Password)){
            return Result.Failure<AuthDto>(new("Email or Password is incorrect!"));
        }

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthDto(user.UserName, user.Email, new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo, true);

    }
    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user) {
        var userClaims = await userManager.GetClaimsAsync(user);
        
        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("guid", user.Id.ToString())
            }
            .Union(userClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
        issuer: _jwt.Issuer,
        audience: _jwt.Audience,
        claims: claims,
        expires: DateTime.Now.AddDays(_jwt.DurationInDays),
        signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}