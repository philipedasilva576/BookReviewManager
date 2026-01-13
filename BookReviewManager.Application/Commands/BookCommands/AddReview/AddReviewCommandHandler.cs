using BookReviewManager.Application.Models;
using BookReviewManager.Core.ExceptionHandler;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.AddReview
{
    public sealed class AddReviewCommandHandler
    : IRequestHandler<AddReviewCommand, ResultVM>
    {
        private readonly IBookRepository _bookRepository;

        public AddReviewCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultVM> Handle(
            AddReviewCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(request.BookId);

                book.AddReview(
                    request.UserId,
                    request.Grade,
                    request.Description,
                    request.BookId);

                await _bookRepository.UpdateAsync(book);

                return ResultVM.Success();
            }
            catch (DomainException ex)
            {
                return ResultVM.Error(ex.Message);
            }
        }
    }
}
