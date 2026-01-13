using BookReviewManager.Application.Commands.LoginCommand;
using BookReviewManager.Application.Validators;
using FluentAssertions;

namespace BookReviewManager.UnitTests.Application.Validators
{
    public class LoginUserCommandValidatorTests
    {
        private readonly LoginUserCommandValidator _validator;

        public LoginUserCommandValidatorTests()
        {
            _validator = new LoginUserCommandValidator();
        }

        [Fact]
        public void Should_Fail_When_Email_Is_Invalid()
        {
            var command = new LoginUserCommand("emailinvalido@teste", "123");

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }
    }
}
