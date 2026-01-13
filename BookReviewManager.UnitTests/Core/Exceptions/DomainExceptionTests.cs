using BookReviewManager.Core.ExceptionHandler;
using FluentAssertions;

namespace BookReviewManager.UnitTests.Core.Exceptions
{
    public class DomainExceptionTests
    {
        [Fact]
        public void ThrowDomainException_ShouldHaveMessage()
        {
            Action act = () => throw new DomainException("Erro de domínio");

            act.Should().Throw<DomainException>()
                .WithMessage("Erro de domínio");
        }
    }
}
