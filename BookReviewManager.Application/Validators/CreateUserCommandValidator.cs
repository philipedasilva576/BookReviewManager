using BookReviewManager.Application.Commands.UserCommands.CreateUser;
using FluentValidation;

namespace BookReviewManager.Application.Validators
{
    public class CreateUserCommandValidator
    : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3)
                .MaximumLength(150);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.")
                .MaximumLength(200);
        }
    }
}
