namespace Application.Features.Chats.Handlers;

using Domain.Repositories;
using Domain.Shared.Results;
using DTOs.Chat;
using MediatR;
using Queries;

public class GetGroupHistoryQueryHandler(IChatRepository chatRepository) : IRequestHandler<GetGroupHistoryQuery, Result<IReadOnlyList<ChatHistoryDto>>> {

    public async Task<Result<IReadOnlyList<ChatHistoryDto>>> Handle(GetGroupHistoryQuery request, CancellationToken cancellationToken) {
        
        if (request.userId == Guid.Empty)
            return Result.Failure<IReadOnlyList<ChatHistoryDto>>(new Error("userId is empty"));

        var chats = await chatRepository.GetChatsForUserAsync(request.userId);

        return ChatHistoryDto.Create(chats.ToList());
    }
}