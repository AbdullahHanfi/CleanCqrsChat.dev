namespace Domain.Repositories;

using Entities;
using Enums;

public interface IMessageRepository : IRepository<Message>
{
    Task<Message?> GetByIdAsync(Guid messageId);

    /// <summary>
    /// Gets a paginated list of messages for a specific chat.
    /// </summary>
    Task<IEnumerable<Message>> GetMessagesForChatAsync(Guid chatId, int page, int pageSize);

    Task CreateAsync(Message message);

    Task<bool> AddReactionAsync(Guid messageId, MessageReaction reaction);
    Task<bool> UpdateDeliveryStatusAsync(Guid messageId, Guid userId, MessageStatus status, DateTime? readAt = null);
}