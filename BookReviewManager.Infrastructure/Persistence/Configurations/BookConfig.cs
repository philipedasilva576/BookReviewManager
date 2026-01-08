using BookReviewManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReviewManager.Infrastructure.Persistence.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(b => b.ISBN)
                .IsUnique();

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.Genre)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(b => b.PublishYear)
                .IsRequired();

            builder.Property(b => b.PageCount)
                .IsRequired();

            builder.Property(b => b.AverageReview)
                .HasPrecision(3, 2);

            builder.Property(b => b.BookCover)
                .HasColumnType("varbinary(max)");

            builder.Property(b => b.CreatedAt)
                .IsRequired();

            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
