namespace CleanCqrsChat.dev.Domain.Entities;

using Enums;

public class Chat {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }
    public ChatType Type { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? LastMessageAt { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public User Creator { get; set; }
    public ICollection<ChatMember> Members { get; set; } = new List<ChatMember>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}