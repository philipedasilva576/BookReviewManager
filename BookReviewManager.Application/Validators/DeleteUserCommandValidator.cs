using BookReviewManager.Application.Commands.UserCommands.DeleteUsers;
using FluentValidation;

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
