using BookReviewManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReviewManager.Infrastructure.Persistence.Configurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Grade)
                .IsRequired();

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Regra: um usuário só pode avaliar um livro uma vez
            builder.HasIndex(r => new { r.BookId, r.UserId })
                .IsUnique();
        }
    }
}
