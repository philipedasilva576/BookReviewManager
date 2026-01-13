using BookReviewManager.Application.Queries;
using BookReviewManager.Core.Repositories;
using BookReviewManager.Infrastructure.Persistence;
using BookReviewManager.UnitTests.Core.Fakers;
using FluentAssertions;
using Moq;

namespace BookReviewManager.UnitTests.Application.Queries.Book
{
    public class GetBookByIdQueryHandlerTests
    {
        private readonly Mock<IBookRepository> _repositoryMock;
        private readonly Mock<BookReviewDbContext> _context;
        private readonly GetBookByIdQueryHandler _handler;

        public GetBookByIdQueryHandlerTests()
        {
            _repositoryMock = new Mock<IBookRepository>();
            _handler = new GetBookByIdQueryHandler(_context.Object);
        }

        [Fact]
        public async Task Should_Return_Book_When_Exists()
        {
            var book = BookFaker.Create().Generate();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(book.Id))
                .ReturnsAsync(book);

            var query = new GetBookByIdQuery(book.Id);

            var result = await _handler.Handle(query, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data!.Title.Should().Be(book.Title);
        }
    }
}
