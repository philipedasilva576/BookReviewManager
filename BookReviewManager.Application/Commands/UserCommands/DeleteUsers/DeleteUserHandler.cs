using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Commands.UserCommands.DeleteUsers
{
    public class DeleteUserHandler
        : IRequestHandler<DeleteUserCommand, ResultVM>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _userRepository.ExistAsync(request.Id);

            await _userRepository.RemoveAsync(request.Id);

            return ResultVM.Success();
        }
    }
}
