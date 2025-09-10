namespace Application.Features.Chats.Handlers;

using Domain.Repositories;
using DTOs.Chat;
using MediatR;
using Queries;

public class GetGroupHistoryQueryHandler(IChatRepository chatRepository) : IRequestHandler<GetGroupHistoryQuery, IReadOnlyList<ChatHistoryDto>> {

    public async Task<IReadOnlyList<ChatHistoryDto>> Handle(GetGroupHistoryQuery request, CancellationToken cancellationToken) {
        var chats = await chatRepository.GetChatsForUserAsync(request.userId);
        return ChatHistoryDto.Create(chats.ToList());
    }
}