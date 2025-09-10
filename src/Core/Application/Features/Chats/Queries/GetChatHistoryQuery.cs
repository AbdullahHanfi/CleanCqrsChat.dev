namespace Application.Features.Chats.Queries;

using DTOs.Chat;
using MediatR;

public record GetGroupHistoryQuery(Guid userId) : IRequest<IReadOnlyList<ChatHistoryDto>>; 