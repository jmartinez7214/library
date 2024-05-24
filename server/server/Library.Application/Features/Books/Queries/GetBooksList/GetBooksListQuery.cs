using MediatR;

namespace Library.Application.Features.Books.Queries.GetBooksList
{
    public class GetBooksListQuery : IRequest<List<BooksVm>>
    {
        //public string _BookName { get; set; } = string.Empty;

        //public GetBooksListQuery(string BookName)
        //{
        //    _BookName = BookName ?? throw new ArgumentNullException(nameof(BookName));
        //}
    }
}
