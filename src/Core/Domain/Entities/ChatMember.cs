namespace Domain.Entities;

using Enums;

public class ChatMember {
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
    public MemberRole Role { get; set; } = MemberRole.Member;
    public DateTime JoinedAt { get; set; }
    public DateTime? LastReadAt { get; set; }
    public bool IsMuted { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
}