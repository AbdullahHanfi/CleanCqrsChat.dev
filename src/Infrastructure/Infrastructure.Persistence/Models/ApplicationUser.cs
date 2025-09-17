using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
