namespace BookReviewManager.Application.Models
{
    public class BookListItemViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public decimal AverageReview { get; init; }
    }
}
