using BookReviewManager.Application.Models;
using BookReviewManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Application.Queries
{
    public class GetBooksQueryHandler
    : IRequestHandler<GetBooksQuery, ResultVM<IEnumerable<BookListItemViewModel>>>
    {
        private readonly BookReviewDbContext _context;

        public GetBooksQueryHandler(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ResultVM<IEnumerable<BookListItemViewModel>>> Handle(
            GetBooksQuery request,
            CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .AsNoTracking()
                .Select(b => new BookListItemViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    AverageReview = b.AverageReview
                })
                .ToListAsync(cancellationToken);

            return ResultVM<IEnumerable<BookListItemViewModel>>.Success(books);
        }
    }
}
