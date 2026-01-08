using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookReviewManager.Infrastructure.Persistence
{
    public class BookReviewDbContextFactory
        : IDesignTimeDbContextFactory<BookReviewDbContext>
    {
        public BookReviewDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookReviewDbContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=192.168.0.110;TrustServerCertificate=True;Initial Catalog=BookReviewDb;User ID=sa;Password=paicon"
            );

            return new BookReviewDbContext(optionsBuilder.Options);
        }
    }
}
