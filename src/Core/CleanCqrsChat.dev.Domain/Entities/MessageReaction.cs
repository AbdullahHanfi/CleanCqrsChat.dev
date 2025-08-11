namespace CleanCqrsChat.dev.Domain.Entities;

public class MessageReaction {
    public Guid MessageId { get; set; }
    public Guid UserId { get; set; }
    public string Emoji { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Message Message { get; set; }
    public User User { get; set; }
}