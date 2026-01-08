namespace BookReviewManager.Core.Repositories
{
    public interface IBaseRepository<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}
