using FluentValidation;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name can't be null}")
                .MaximumLength(50).WithMessage("{Name can't exceed 50 characters.}");

            RuleFor(p => p.Author)
                .NotNull().WithMessage("{Author can't be null}")
                .MaximumLength(50).WithMessage("{Author can't exceed 50 characters.}");

            RuleFor(p => p.PublishedDate)
                .NotNull().WithMessage("{PublishedDate can't be null}");
        }
    }
}
