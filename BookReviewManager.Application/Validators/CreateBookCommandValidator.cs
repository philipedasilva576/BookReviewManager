using BookReviewManager.Application.Commands.BookCommands.CreateBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Validators
{
    public class CreateBookCommandValidator
    : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título do livro é obrigatório.")
                .MinimumLength(3).WithMessage("O título deve ter no mínimo 3 caracteres.")
                .MaximumLength(150).WithMessage("O título não pode exceder 150 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MinimumLength(10).WithMessage("A descrição deve ter no mínimo 10 caracteres.")
                .MaximumLength(1000).WithMessage("A descrição não pode exceder 1000 caracteres.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("O ISBN é obrigatório.")
                .Length(10, 13).WithMessage("O ISBN deve ter entre 10 e 13 caracteres.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("O autor é obrigatório.")
                .MaximumLength(150);

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("A editora é obrigatória.")
                .MaximumLength(150);

            RuleFor(x => x.PublishYear)
                .GreaterThan(1000).WithMessage("Ano de publicação inválido.")
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("O ano de publicação não pode ser no futuro.");

            RuleFor(x => x.PageCount)
                .GreaterThan(0).WithMessage("O livro deve ter ao menos uma página.");
        }
    }
}
