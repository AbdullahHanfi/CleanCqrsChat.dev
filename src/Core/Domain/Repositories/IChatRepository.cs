namespace Domain.Repositories;

using Entities;

public interface IChatRepository : IRepository<Chat>
{
    /// <summary>
    /// Gets all chats a specific user is a member of.
    /// This will query the embedded 'Members' array.
    /// </summary>
    Task<IEnumerable<Chat>> GetChatsForUserAsync(Guid userId);

    /// <summary>
    /// Finds a direct, one-on-one chat between two specific users.
    /// </summary>
    Task<Chat?> FindDirectChatBetweenUsersAsync(Guid userId1, Guid userId2);

    Task CreateAsync(Chat chat);
    Task<bool> UpdateAsync(Chat chat); 
    Task<bool> DeleteAsync(Guid chatId);
}