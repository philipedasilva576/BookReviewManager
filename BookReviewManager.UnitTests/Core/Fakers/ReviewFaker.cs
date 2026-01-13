using Bogus;
using BookReviewManager.Core.Entities;

namespace BookReviewManager.UnitTests.Core.Fakers
{
    public static class ReviewFaker
    {
        public static Faker<Review> Create(int userId, int bookId)
        {
            return new Faker<Review>()
                .CustomInstantiator(f => new Review(
                    f.Random.Int(1, 5),
                    f.Lorem.Sentence(),
                    userId,
                    bookId
                ));
        }
    }
}
