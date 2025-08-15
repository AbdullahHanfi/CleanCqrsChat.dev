namespace Domain.Entities;

using Enums;

public class MessageDelivery {
    public Guid UserId { get; set; }
    public MessageStatus Status { get; set; } = MessageStatus.Sent;
    public DateTime DeliveredAt { get; set; }
    public DateTime? ReadAt { get; set; }
}