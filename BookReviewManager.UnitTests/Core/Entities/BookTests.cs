using BookReviewManager.Core.ExceptionHandler;
using BookReviewManager.UnitTests.Core.Fakers;
using FluentAssertions;

namespace BookReviewManager.UnitTests.Core.Entities
{
    public class BookTests
    {
        [Fact]
        public void CreateBook_ShouldCreateSuccessfully()
        {
            var book = BookFaker.Create().Generate();

            book.Should().NotBeNull();
            book.Title.Should().NotBeNullOrEmpty();
            book.ISBN.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void AddReview_ShouldAddReviewAndRecalculateAverage()
        {
            var book = BookFaker.Create().Generate();

            var review1 = ReviewFaker.Create(1, book.Id).Generate();
            var review2 = ReviewFaker.Create(2, book.Id).Generate();

            book.AddReview(review1.UserId,review1.Grade, review1.Description,review1.BookId);
            book.AddReview(review2.UserId, review2.Grade, review2.Description, review2.BookId);

            book.Reviews.Should().HaveCount(2);
            book.AverageReview.Should().BeGreaterThan(0);
        }

        [Fact]
        public void AddReview_ShouldNotAllowSameUserMoreThanOnce()
        {
            var book = BookFaker.Create().Generate();

            var review1 = ReviewFaker.Create(1, book.Id).Generate();
            var review2 = ReviewFaker.Create(1, book.Id).Generate();

            book.AddReview(review1.UserId, review1.Grade, review1.Description, review1.BookId);

            Action act = () => book.AddReview(review2.UserId, review2.Grade, review2.Description, review2.BookId);

            act.Should().Throw<DomainException>()
                .WithMessage("Usuário já avaliou este livro.");
        }

        [Fact]
        public void AddReview_ShouldNotAllowInvalidGrade()
        {
            var book = BookFaker.Create().Generate();

            Action act = () => book.AddReview(1,6, "Teste de nota de avaliação",1);

            act.Should().Throw<DomainException>()
                .WithMessage("Nota deve ser entre 1 e 5.");
        }
    }
}
