namespace Domain.Enums;

[Flags]
public enum MessageType {
    Text = 1,
    Image = 2,
    Video = 4,
    Audio = 8,
    Document = 16,
    Reply = 32       // Reply to another message
}