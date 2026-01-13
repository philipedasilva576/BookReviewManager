using BookReviewManager.Application.Commands.UserCommands.CreateUser;
using BookReviewManager.Core.Repositories;
using FluentAssertions;
using Moq;

namespace BookReviewManager.UnitTests.Application.Commands.User
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _repositoryMock = new Mock<IUserRepository>();

            _handler = new CreateUserCommandHandler(
                _repositoryMock.Object
            );
        }

        [Fact]
        public async Task Should_Create_User_Successfully()
        {
            // Arrange
            var command = new CreateUserCommand(
                "philipe.info@fenabrave.org.br",
                "Philipe Silva",
                "123456",
                "admin"
            );

            _repositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<BookReviewManager.Core.Entities.User>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();

            _repositoryMock.Verify(
                r => r.CreateAsync(It.IsAny<BookReviewManager.Core.Entities.User>()),
                Times.Once
            );
        }
    }
}
