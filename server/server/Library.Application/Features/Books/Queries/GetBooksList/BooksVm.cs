namespace Library.Application.Features.Books.Queries.GetBooksList
{
    public class BooksVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
