namespace CleanCqrsChat.dev.Domain.Entities;

using Enums;

public class Message {
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public Guid SenderId { get; set; }
    public string Content { get; set; }
    public MessageType Type { get; set; } = MessageType.Text;
    public MessageStatus Status { get; set; } = MessageStatus.Sending;
    public Guid? ReplyToMessageId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsEdited { get; set; } = false;

    // Navigation properties
    public Chat Chat { get; set; }
    public User Sender { get; set; }
    public Message? ReplyToMessage { get; set; }
    public ICollection<MessageAttachment> Attachments { get; set; } = new List<MessageAttachment>();
    public ICollection<MessageReaction> Reactions { get; set; } = new List<MessageReaction>();
    public ICollection<MessageDelivery> Deliveries { get; set; } = new List<MessageDelivery>();
}