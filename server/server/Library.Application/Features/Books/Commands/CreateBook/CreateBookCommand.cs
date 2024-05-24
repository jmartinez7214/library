using MediatR;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
    }
}
