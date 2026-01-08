using BookReviewManager.Application.Models;
using BookReviewManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.UserCommands.UpdateUser
{
    public class ValidateUpdateUserCommandBehavior
        : IPipelineBehavior<UpdateUserCommand, ResultVM>
    {
        private readonly BookReviewDbContext _context;

        public ValidateUpdateUserCommandBehavior(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ResultVM> Handle(
            UpdateUserCommand request,
            RequestHandlerDelegate<ResultVM> next,
            CancellationToken cancellationToken)
        {
            var userExists = _context.Users.Any(u => u.Id == request.Id);

            if (!userExists)
                return ResultVM.Error("Usuário não encontrado.");

            var emailAlreadyInUse = _context.Users.Any(u =>
                u.Email == request.Email && u.Id != request.Id);

            if (emailAlreadyInUse)
                return ResultVM.Error("Este e-mail já está sendo utilizado por outro usuário.");

            return await next();
        }
    }
}
