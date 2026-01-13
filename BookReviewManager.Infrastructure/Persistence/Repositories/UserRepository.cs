using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookReviewDbContext context)
            : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email, string password)
        {
            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> EmailAlreadyExistsAsync(string email, int userId)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.Id != userId);
        }
    }
}
