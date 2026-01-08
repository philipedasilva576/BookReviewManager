using BookReviewManager.Application.Commands.BookCommands.UpdateBookCover;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Validators
{
    public class UpdateBookCoverCommandValidator
    : AbstractValidator<UpdateBookCoverCommand>
    {
        public UpdateBookCoverCommandValidator()
        {
            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage("Livro inválido.");

            RuleFor(x => x.BookCover)
                .NotNull().WithMessage("A capa do livro é obrigatória.")
                .Must(x => x.Length > 0)
                .WithMessage("A capa do livro não pode estar vazia.");
        }
    }
}
