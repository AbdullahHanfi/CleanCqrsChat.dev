namespace Application.DTOs.User;

using Domain.Entities;

public class UserDto {

    public Guid Id { get; set; }
    public string Role { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime? LastReadAt { get; set; }
    public bool IsMuted { get; set; }
    public bool IsBlocked { get; set; }

    public static UserDto Create(ChatMember? chatMember) {
        if (chatMember == null) return new();

        return new UserDto
        {
            Id = chatMember.UserId,
            Role = chatMember.Role.ToString(),
            JoinedAt = chatMember.JoinedAt,
            LastReadAt = chatMember.LastReadAt,
            IsBlocked = chatMember.IsBlocked,
            IsMuted = chatMember.IsMuted
        };
    }

    public static List<UserDto> Create(List<ChatMember>? chatMembers) {
        if (chatMembers == null || chatMembers.Count == 0)
            return new();

        return chatMembers.Select(Create).ToList();
    }
}