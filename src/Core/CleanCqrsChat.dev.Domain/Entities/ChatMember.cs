namespace CleanCqrsChat.dev.Domain.Entities;

using Enums;

public class ChatMember {
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    public MemberRole Role { get; set; } = MemberRole.Member;
    public DateTime JoinedAt { get; set; }
    public DateTime? LastReadAt { get; set; }
    public bool IsMuted { get; set; } = false;
    public bool IsBlocked { get; set; } = false;

    // Navigation properties
    public Chat Chat { get; set; }
    public User User { get; set; }
}