using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.UpdateBookCover
{
    public sealed class UpdateBookCoverCommandHandler
    : IRequestHandler<UpdateBookCoverCommand, ResultVM>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCoverCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultVM> Handle(
            UpdateBookCoverCommand request,
            CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            book.SetBookCover(request.BookCover);

            await _bookRepository.UpdateAsync(book);

            return ResultVM.Success();
        }
    }
}
