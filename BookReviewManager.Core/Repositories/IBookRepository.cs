using BookReviewManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Core.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book?> GetByIsbnAsync(string isbn);
        Task<bool> ExistsByIsbnAsync(string isbn);
        Task<IEnumerable<Book>> GetWithReviewsAsync();
    }
}
