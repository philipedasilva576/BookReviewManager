using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.LoginCommand
{
    public class ValidateLoginUserCommandBehavior
        : IPipelineBehavior<LoginUserCommand, ResultVM<LoginUserResponseDto>>
    {
        private readonly IUserRepository _userRepository;

        public ValidateLoginUserCommandBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM<LoginUserResponseDto>> Handle(
            LoginUserCommand request,
            RequestHandlerDelegate<ResultVM<LoginUserResponseDto>> next,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return ResultVM<LoginUserResponseDto>
                    .Error("E-mail é obrigatório.");
            }

            var userExists = await _userRepository
                .ExistsByEmailAsync(request.Email);

            if (!userExists)
            {
                return ResultVM<LoginUserResponseDto>
                    .Error("Usuário não encontrado.");
            }

            return await next();
        }
    }
}
