using BookReviewManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
     where TEntity : class
    {
        protected readonly BookReviewDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(BookReviewDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
                return;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> ExistAsync(int id)
        {
            return await _dbSet.FindAsync(id) != null;
        }
    }
}

