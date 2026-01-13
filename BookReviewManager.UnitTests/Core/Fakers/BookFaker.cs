using Bogus;
using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Enums;

namespace BookReviewManager.UnitTests.Core.Fakers
{
    public static class BookFaker
    {
        public static Faker<Book> Create()
        {
            return new Faker<Book>()
                .CustomInstantiator(f => new Book(
                    f.Lorem.Sentence(3),
                    f.Lorem.Paragraph(),
                    f.Random.Replace("###-##########"),
                    f.Name.FullName(),
                    f.Company.CompanyName(),
                    f.PickRandom<GenreEnum>(),
                    f.Date.Past(10).Year,
                    f.Random.Int(50, 800)
                ));
        }
    }
}
