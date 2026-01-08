using BookReviewManager.Application.Commands.UserCommands.DeleteUsers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Validators
{
    public class DeleteUserCommandValidator
        : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id do usuário deve ser maior que zero.");
        }
    }
}
