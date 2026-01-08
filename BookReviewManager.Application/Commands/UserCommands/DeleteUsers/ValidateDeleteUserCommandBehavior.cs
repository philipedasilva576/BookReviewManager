using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Commands.UserCommands.DeleteUsers
{
    public class ValidateDeleteUserCommandBehavior
        : IPipelineBehavior<DeleteUserCommand, ResultVM>
    {
        private readonly IUserRepository _userRepository;

        public ValidateDeleteUserCommandBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM> Handle(
            DeleteUserCommand request,
            RequestHandlerDelegate<ResultVM> next,
            CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                return ResultVM.Error("Id do usuário inválido.");
            }

            var exists = await _userRepository.ExistAsync(request.Id);

            if (!exists)
            {
                return ResultVM.Error("Usuário não encontrado.");
            }

            return await next();
        }
    }
}
