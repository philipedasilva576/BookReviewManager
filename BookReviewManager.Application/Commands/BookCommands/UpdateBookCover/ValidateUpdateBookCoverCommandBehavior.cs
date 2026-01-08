using BookReviewManager.Application.Models;
using BookReviewManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.BookCommands.UpdateBookCover
{
    public sealed class ValidateUpdateBookCoverCommandBehavior
    : IPipelineBehavior<UpdateBookCoverCommand, ResultVM>
    {
        private const int MaxCoverSizeInBytes = 5 * 1024 * 1024; // 5MB

        private readonly BookReviewDbContext _context;

        public ValidateUpdateBookCoverCommandBehavior(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ResultVM> Handle(
            UpdateBookCoverCommand request,
            RequestHandlerDelegate<ResultVM> next,
            CancellationToken cancellationToken)
        {
            if (request.BookCover is null || request.BookCover.Length == 0)
                return ResultVM.Error("A capa do livro não pode ser vazia.");

            if (request.BookCover.Length > MaxCoverSizeInBytes)
                return ResultVM.Error("A capa do livro excede o tamanho máximo permitido (5MB).");

            var bookExists = await _context.Books
                .AnyAsync(b => b.Id == request.BookId, cancellationToken);

            if (!bookExists)
                return ResultVM.Error("Livro não encontrado.");

            return await next();
        }
    }

}
