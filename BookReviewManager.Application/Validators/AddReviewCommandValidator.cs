using BookReviewManager.Application.Commands.BookCommands.AddReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Validators
{
    public class AddReviewCommandValidator
    : AbstractValidator<AddReviewCommand>
    {
        public AddReviewCommandValidator()
        {
            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage("Livro inválido.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Usuário inválido.");

            RuleFor(x => x.Grade)
                .InclusiveBetween(1, 5)
                .WithMessage("A nota deve estar entre 1 e 5.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição da avaliação é obrigatória.")
                .MaximumLength(500)
                .WithMessage("A descrição não pode exceder 500 caracteres.");
        }
    }
}
