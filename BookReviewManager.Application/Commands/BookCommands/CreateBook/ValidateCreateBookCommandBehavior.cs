using BookReviewManager.Application.Models;
using BookReviewManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Application.Commands.BookCommands.CreateBook
{
    public sealed class ValidateCreateBookCommandBehavior
     : IPipelineBehavior<CreateBookCommand, ResultVM<int>>
    {
        private readonly BookReviewDbContext _context;

        public ValidateCreateBookCommandBehavior(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ResultVM<int>> Handle(
            CreateBookCommand request,
            RequestHandlerDelegate<ResultVM<int>> next,
            CancellationToken cancellationToken)
        {
            var isbnAlreadyExists = await _context.Books
                .AnyAsync(b => b.ISBN == request.ISBN, cancellationToken);

            if (isbnAlreadyExists)
            {
                return ResultVM<int>.Error("Já existe um livro cadastrado com este ISBN.");
            }

            if (request.PublishYear < 1500 || request.PublishYear > DateTime.Now.Year)
            {
                return ResultVM<int>.Error("Ano de publicação inválido.");
            }

            return await next();
        }
    }

}
