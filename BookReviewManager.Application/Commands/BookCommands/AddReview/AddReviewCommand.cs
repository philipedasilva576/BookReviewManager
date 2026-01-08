using BookReviewManager.Application.Models;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.AddReview
{
    public sealed record AddReviewCommand(
    int BookId,
    int UserId,
    int Grade,
    string Description
) : IRequest<ResultVM>;
}
