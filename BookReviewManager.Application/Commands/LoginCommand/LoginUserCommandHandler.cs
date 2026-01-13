using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using BookReviewManager.Infrastructure.Auth;
using FluentValidation;
using MediatR;

namespace BookReviewManager.Application.Commands.LoginCommand
{
    public class LoginUserCommandHandler
        : IRequestHandler<LoginUserCommand, ResultVM<LoginUserResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(
            IUserRepository userRepository,
            IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<ResultVM<LoginUserResponseDto>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Gera o hash da senha
            var passwordHash = _authService.ComputeHash(request.Password);

            // 2️⃣ Busca usuário
            var user = await _userRepository
                .GetByEmailAsync(request.Email, passwordHash);

            if (user is null)
            {
                return ResultVM<LoginUserResponseDto>
                    .Error("Usuário ou senha inválidos.");
            }

            // 3️⃣ Gera token
            var token = _authService.GenereteToken(user.Email, user.Role);

            // 4️⃣ Monta DTO de resposta
            var response = new LoginUserResponseDto
            {
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                Token = token
            };

            return ResultVM<LoginUserResponseDto>.Success(response);
        }
    }
}
