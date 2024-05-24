using Library.Domain;

namespace Library.Application.Contracts.Persistence
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<Book> GetBookByName(string bookName);
        Task<Book> GetBookAndDetailsById(int id);
    }
}
