using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    internal class BookDetailRepository : RepositoryBase<BookDetail>, IBookDetailRepository
    {
        public BookDetailRepository(LibraryDbContext context) : base(context)
        {

        }

        public async Task<BookDetail> GetByIdAndPageAsync(int id, int page)
        {
            return await _context.BookDetails!.Where(x => x.BookId == id && x.Page == page).FirstOrDefaultAsync();
        }
    }
}
