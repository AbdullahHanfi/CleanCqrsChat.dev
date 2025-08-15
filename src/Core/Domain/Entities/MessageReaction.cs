namespace Domain.Entities;

public class MessageReaction {
    public Guid UserId { get; set; }
    public string Emoji { get; set; }
    public DateTime CreatedAt { get; set; }
}