using BookReviewManager.Application.Models;
using BookReviewManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Application.Commands.UserCommands.CreateUser
{
    public sealed class ValidateCreateUserCommandBehavior
     : IPipelineBehavior<CreateUserCommand, ResultVM<int>>
    {
        private readonly BookReviewDbContext _context;

        public ValidateCreateUserCommandBehavior(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ResultVM<int>> Handle(
            CreateUserCommand request,
            RequestHandlerDelegate<ResultVM<int>> next,
            CancellationToken cancellationToken)
        {
            var emailExists = await _context.Users
                .AnyAsync(u => u.Email == request.Email, cancellationToken);

            if (emailExists)
            {
                return ResultVM<int>.Error("Já existe um usuário com este e-mail.");
            }

            return await next();
        }
    }

}
