namespace Application.DTOs.Chat;

using Domain.Entities;
using User;

public class ChatHistoryDto {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }
    public string Type { get; set; }
    public UserDto Creator { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Privacy { get; set; }
    public List<UserDto> Members { get; set; }
    
    public static ChatHistoryDto Create(Chat chat) {
        return new ChatHistoryDto
        {
            Id = chat.Id,
            Name = chat.Name,
            Description = chat.Description,
            Avatar = chat.Avatar,
            Type = chat.Type.ToString(),
            Creator = UserDto.Create(chat.Members.First(e => e.UserId == chat.CreatedBy)),
            CreatedAt = chat.CreatedAt,
            Privacy = chat.Privacy.ToString(),
            Members = UserDto.Create(chat.Members.ToList())
        };
    }
    
    public static List<ChatHistoryDto> Create(List<Chat> Chats) {
        return Chats.Select(Create).ToList();
    }
}