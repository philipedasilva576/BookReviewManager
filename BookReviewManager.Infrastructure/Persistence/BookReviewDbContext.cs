using BookReviewManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookReviewManager.Infrastructure.Persistence
{
    public class BookReviewDbContext : DbContext
    {
        public BookReviewDbContext(DbContextOptions<BookReviewDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookReviewDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
