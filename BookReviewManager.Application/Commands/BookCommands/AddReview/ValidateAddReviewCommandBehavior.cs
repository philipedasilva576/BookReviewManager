using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Commands.BookCommands.AddReview
{
    public sealed class ValidateAddReviewCommandBehavior
        : IPipelineBehavior<AddReviewCommand, ResultVM<int>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public ValidateAddReviewCommandBehavior(
            IBookRepository bookRepository,
            IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<ResultVM<int>> Handle(
            AddReviewCommand request,
            RequestHandlerDelegate<ResultVM<int>> next,
            CancellationToken cancellationToken)
        {
            if (!await _bookRepository.ExistAsync(request.BookId))
                return ResultVM<int>.Error("Livro não encontrado.");

            if (!await _userRepository.ExistAsync(request.UserId))
                return ResultVM<int>.Error("Usuário não encontrado.");

            return await next();
        }
    }


}
