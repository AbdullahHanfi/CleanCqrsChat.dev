namespace Application.Features.Chats.Queries;

using Domain.Shared.Results;
using DTOs.Chat;
using MediatR;

public record GetGroupHistoryQuery(Guid userId) : IRequest<Result<IReadOnlyList<ChatHistoryDto>>>;