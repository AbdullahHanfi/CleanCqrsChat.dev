namespace Application.Features.Chats.GetChatHistory;

using Abstractions.Messaging;
using DTOs.Chat;
using Domain.Repositories;
using Domain.Shared.Results;

public class GetGroupHistoryQueryHandler(IChatRepository chatRepository) : IQueryHandler<GetGroupHistoryQuery, IReadOnlyList<ChatHistoryDto>> {

    public async Task<Result<IReadOnlyList<ChatHistoryDto>>> Handle(GetGroupHistoryQuery request, CancellationToken cancellationToken) {
    
        if (request.UserId == Guid.Empty)
            return Result.Failure<IReadOnlyList<ChatHistoryDto>>(new Error("userId is empty"));
    
        var chats = await chatRepository.GetChatsForUserAsync(request.UserId);
    
        return ChatHistoryDto.Create(chats.ToList());
    }
}