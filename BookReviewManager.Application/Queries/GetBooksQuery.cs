using BookReviewManager.Application.Models;
using MediatR;

namespace BookReviewManager.Application.Queries
{
    public record GetBooksQuery()
    : IRequest<ResultVM<IEnumerable<BookListItemViewModel>>>;
}
