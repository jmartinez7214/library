using MediatR;

namespace Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
