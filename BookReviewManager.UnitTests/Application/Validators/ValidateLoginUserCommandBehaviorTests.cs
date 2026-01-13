using BookReviewManager.Application.Commands.LoginCommand;
using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Repositories;
using FluentAssertions;
using Moq;

namespace BookReviewManager.UnitTests.Application.Validators
{
    public class ValidateLoginUserCommandBehaviorTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly ValidateLoginUserCommandBehavior _behavior;

        public ValidateLoginUserCommandBehaviorTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _behavior = new ValidateLoginUserCommandBehavior(_repositoryMock.Object);
        }

        [Fact]
        public async Task Should_Return_Error_When_User_Not_Found()
        {
            var command = new LoginUserCommand("test@test.com", "hash");

            _repositoryMock
                .Setup(r => r.GetByEmailAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((User?)null);

            var result = await _behavior.Handle(
                command,
                () => Task.FromResult(ResultVM<LoginUserResponseDto>.Success(null)),
                CancellationToken.None
            );

            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be("Usuário ou senha inválidos");
        }
    }
}
