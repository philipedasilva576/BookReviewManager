using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultVM>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);


            user.Update(request.Name, request.Email);

            await _userRepository.UpdateAsync(user);

            return ResultVM.Success();
        }
    }
}
