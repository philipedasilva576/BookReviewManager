using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Repositories;
using BookReviewManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries
{
    public class GetBookByIdQueryHandler
     : IRequestHandler<GetBookByIdQuery, ResultVM<BookDto>>
    {
        private readonly BookReviewDbContext _context;

        public GetBookByIdQueryHandler(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ResultVM<BookDto>> Handle(
            GetBookByIdQuery request,
            CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .AsNoTracking()
                .Where(b => b.Id == request.Id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Publisher = b.Publisher,
                    Genre = b.Genre,
                    PublishYear = b.PublishYear,
                    PageCount = b.PageCount,
                    AverageReview = b.AverageReview
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (book is null)
                return ResultVM<BookDto>.Error("Livro não encontrado.");

            return ResultVM<BookDto>.Success(book);
        }

    }
}
