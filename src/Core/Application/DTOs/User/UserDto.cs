namespace Application.DTOs.User;

using Domain.Entities;

public class UserDto {
    
    public Guid Id { get; set; }
    public string Role { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime? LastReadAt { get; set; }
    public bool IsMuted { get; set; }
    public bool IsBlocked { get; set; }
    
    public static UserDto Create(ChatMember chatMember)
    {
        return new UserDto
        {
            Id = chatMember.UserId,
            Role =  chatMember.Role.ToString(),
            JoinedAt = chatMember.JoinedAt,
            LastReadAt = chatMember.LastReadAt,
            IsBlocked = chatMember.IsBlocked,
            IsMuted = chatMember.IsMuted
        };
    }
    
    public static List<UserDto> Create(List<ChatMember> ChatMembers) {
        return ChatMembers.Select(Create).ToList();
    }
}