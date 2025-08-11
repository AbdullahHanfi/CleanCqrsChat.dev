namespace CleanCqrsChat.dev.Domain.Enums;
[Flags]
public enum NotificationType {
    Message=0,
    Mention=1,
    Reaction=2,
    Member_joined=4,
    Member_left=8,
    Member_added=16,
    Member_removed=32,
    Role_changed=64
    
}