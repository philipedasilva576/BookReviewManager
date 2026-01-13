using BookReviewManager.Application.Commands.LoginCommand;
using FluentValidation;

namespace BookReviewManager.Application.Validators
{
    public class LoginUserCommandValidator
        : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.")
                .MaximumLength(200);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve conter no mínimo 6 caracteres.");
        }
    }
}
