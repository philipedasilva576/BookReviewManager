using BookReviewManager.Application.Models;
using MediatR;

namespace BookReviewManager.Application.Commands.UserCommands.DeleteUsers
{
    public sealed record DeleteUserCommand(int Id)
      : IRequest<ResultVM>;
}
