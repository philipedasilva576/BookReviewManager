using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using BookReviewManager.Core.ExceptionHandler;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.CreateBook
{
    public sealed class CreateBookCommandHandler
    : IRequestHandler<CreateBookCommand, ResultVM<int>>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultVM<int>> Handle(
            CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var book = new Book(
                    request.Title,
                    request.Description,
                    request.ISBN,
                    request.Author,
                    request.Publisher,
                    request.Genre,
                    request.PublishYear,
                    request.PageCount);

                await _bookRepository.CreateAsync(book);

                return ResultVM<int>.Success(book.Id);
            }
            catch (DomainException ex)
            {
                return ResultVM<int>.Error(ex.Message);
            }
        }
    }
}
