using MediatR;

namespace Library.Application.Features.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookVm>
    {
        public int _Id { get; set; }

        public GetBookQuery(int id)
        {
            _Id = id;
        }
    }
}
