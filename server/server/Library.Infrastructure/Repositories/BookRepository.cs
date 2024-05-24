using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }

        public async Task<Book> GetBookAndDetailsById(int id)
        {
            return await _context.Books!
                .Include(x => x.BookDetails)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookByName(string bookName)
        {
            return await _context.Books!.Where(x => x.Name == bookName).FirstOrDefaultAsync();
        }
    }
}
