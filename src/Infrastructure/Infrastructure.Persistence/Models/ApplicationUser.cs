using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? ProfilePictureUrl { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<RefreshToken>? RefreshTokens { get; set; } = new();
}
