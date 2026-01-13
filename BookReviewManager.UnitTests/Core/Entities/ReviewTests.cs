using BookReviewManager.Core.Entities;
using BookReviewManager.Core.ExceptionHandler;
using FluentAssertions;

namespace BookReviewManager.UnitTests.Core.Entities
{
    public class ReviewTests
    {
        [Fact]
        public void CreateReview_WithValidData_ShouldSucceed()
        {
            var review = new Review(5, "Teste de Criação para Sucesso", 1, 1);

            review.Grade.Should().Be(5);
            review.Description.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void CreateReview_WithInvalidGrade_ShouldThrowException(int grade)
        {
            Action act = () => new Review(grade, "Testando", 1, 1);

            act.Should().Throw<DomainException>()
                .WithMessage("Nota deve ser entre 1 e 5.");
        }
    }
}
