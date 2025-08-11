namespace CleanCqrsChat.dev.Domain.Entities;

using Enums;

public class MessageDelivery {
    public Guid MessageId { get; set; }
    public Guid UserId { get; set; }
    public MessageStatus Status { get; set; } = MessageStatus.Sent;
    public DateTime DeliveredAt { get; set; }
    public DateTime? ReadAt { get; set; }

    // Navigation properties
    public Message Message { get; set; }
    public User User { get; set; }
}