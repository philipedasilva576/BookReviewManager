namespace BookReviewManager.Core.Entities
{
    public class Review : BaseEntity
    {
        protected Review() { }
        public Review(int grade, string description, int userId, int bookId)
        {
            Grade = grade;
            Description = description;
            UserId = userId;
            BookId = bookId;
        }

        public int Grade { get; private set; }
        public string Description { get; private set; }

        public int UserId { get; private set; }
        public int BookId { get; private set; }

        public User User { get; private set; }
        public Book Book { get; private set; }
    }
}
