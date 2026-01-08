using BookReviewManager.Application.Models;
using BookReviewManager.Core.Enums;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.UpdateBookCover
{
    public record UpdateBookCoverCommand(
     int BookId,
     byte[] BookCover
 ) : IRequest<ResultVM>;
}
