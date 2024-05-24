using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IRequest<BookDetailVm>
    {
        public int _Id { get; set; }
        public int _Page { get; set; }

        public GetBookDetailQuery(int id, int page)
        {
            _Id = id;
            _Page = page;
        }
    }
}
