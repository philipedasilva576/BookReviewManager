using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Infrastructure.Persistence.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookReviewDbContext context)
            : base(context)
        {
        }

        public async Task<Book?> GetByIsbnAsync(string isbn)
        {
            return await _context.Books
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.ISBN == isbn);
        }

        public async Task<bool> ExistsByIsbnAsync(string isbn)
        {
            return await _context.Books
                .AnyAsync(b => b.ISBN == isbn);
        }

        public async Task<IEnumerable<Book>> GetWithReviewsAsync()
        {
            return await _context.Books
                .Include(b => b.Reviews)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
