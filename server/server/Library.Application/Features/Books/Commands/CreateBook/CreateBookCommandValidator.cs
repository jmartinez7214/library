using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name can't be blank}")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name can't exceed 50 characters.}");

            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("{Author can't be blank}")
                .NotNull()
                .MaximumLength(50).WithMessage("{Author can't exceed 50 characters.}");

            RuleFor(p => p.PublishedDate)
                .NotEmpty().WithMessage("{PublishedDate can't be blank}")
                .NotNull();
        }
    }
}
