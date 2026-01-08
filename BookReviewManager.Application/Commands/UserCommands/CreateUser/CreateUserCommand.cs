using BookReviewManager.Application.Models;
using MediatR;

namespace BookReviewManager.Application.Commands.UserCommands.CreateUser
{
    public sealed record CreateUserCommand(
    string Email,
    string Name
) : IRequest<ResultVM<int>>;
}
