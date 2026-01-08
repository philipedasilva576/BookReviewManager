using BookReviewManager.Application.Commands.UserCommands.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Validators
{
    public class UpdateUserCommandValidator
     : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id do usuário inválido.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(150)
                .WithMessage("O nome deve ter no máximo 150 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("E-mail inválido.")
                .MaximumLength(200)
                .WithMessage("O e-mail deve ter no máximo 200 caracteres.");
        }
    }
}
