using BookReviewManager.Application.Models;
using BookReviewManager.Core.Enums;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.CreateBook
{
    public sealed record CreateBookCommand(
     string Title,
     string Description,
     string ISBN,
     string Author,
     string Publisher,
     GenreEnum Genre,
     int PublishYear,
     int PageCount
 ) : IRequest<ResultVM<int>>;
}
