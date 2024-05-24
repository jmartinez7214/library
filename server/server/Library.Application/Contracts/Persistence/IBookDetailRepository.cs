using Library.Domain;

namespace Library.Application.Contracts.Persistence
{
    public interface IBookDetailRepository : IAsyncRepository<BookDetail>
    {
        Task<BookDetail> GetByIdAndPageAsync(int id, int page);
    }
}
