namespace Application.Features.Chats.GetChatHistory;

using Abstractions.Caching;
using Abstractions.Messaging;
using DTOs.Chat;

public record GetGroupHistoryQuery(Guid UserId) : IQuery<IReadOnlyList<ChatHistoryDto>>;
