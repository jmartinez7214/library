using Library.Domain;

namespace Library.Application.Features.Books.Queries.GetBook
{
    public class BookVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Count { get; set; }
    }
}
