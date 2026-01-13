using BookReviewManager.UnitTests.Core.Fakers;
using FluentAssertions;

namespace BookReviewManager.UnitTests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public void CreateUser_ShouldCreateSuccessfully()
        {
            var user = UserFaker.Create().Generate();

            user.Email.Should().NotBeNullOrEmpty();
            user.Name.Should().NotBeNullOrEmpty();
        }
    }
}
