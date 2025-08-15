namespace Domain.Entities;

public class MessageAttachment {
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public long FileSize { get; set; }
    public string FilePath { get; set; }
    public DateTime CreatedAt { get; set; }
}