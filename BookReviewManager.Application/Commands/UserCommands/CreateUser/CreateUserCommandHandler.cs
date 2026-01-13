using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.UserCommands.CreateUser
{
    public sealed class CreateUserCommandHandler
     : IRequestHandler<CreateUserCommand, ResultVM<int>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM<int>> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _userRepository.ExistsByEmailAsync(request.Email);

            var user = new User(request.Email, request.Name, request.Password, request.Role);

            await _userRepository.CreateAsync(user);

            return ResultVM<int>.Success(user.Id);
        }
    }
}
