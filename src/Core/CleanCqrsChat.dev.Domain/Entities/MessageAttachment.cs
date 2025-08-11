namespace CleanCqrsChat.dev.Domain.Entities;

public class MessageAttachment {
    public Guid Id { get; set; }
    public Guid MessageId { get; set; }
    public string FileName { get; set; }
    public string OriginalFileName { get; set; }
    public string ContentType { get; set; }
    public long FileSize { get; set; }
    public string FilePath { get; set; }
    public string? ThumbnailPath { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Message Message { get; set; }
}