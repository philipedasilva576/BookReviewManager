using BookReviewManager.Core.Enums;
using BookReviewManager.Core.ExceptionHandler;

namespace BookReviewManager.Core.Entities
{
    public class Book : BaseEntity
    {
        protected Book()
        {
            _reviews = new List<Review>();
        }

        public Book(
            string title,
            string description,
            string isbn,
            string author,
            string publisher,
            GenreEnum genre,
            int publishYear,
            int pageCount)
        {
            Title = title;
            Description = description;
            ISBN = isbn;
            Author = author;
            Publisher = publisher;
            Genre = genre;
            PublishYear = publishYear;
            PageCount = pageCount;

            _reviews = new List<Review>();
            AverageReview = 0;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ISBN { get; private set; }
        public string Author { get; private set; }
        public string Publisher { get; private set; }
        public GenreEnum Genre { get; private set; }
        public int PublishYear { get; private set; }
        public int PageCount { get; private set; }
        public decimal AverageReview { get; private set; }
        public byte[]? BookCover { get; private set; }

        private readonly List<Review> _reviews;
        public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

        // 🔥 MÉTODO DE DOMÍNIO
        public void AddReview(int userId, int grade, string description, int bookId)
        {
            // Regra 1: Nota válida
            if (grade < 1 || grade > 5)
                throw new DomainException("A nota de avaliação deve ser entre 1 e 5");

            // Regra 2: Usuário só pode avaliar uma vez
            if (_reviews.Any(r => r.UserId == userId))
                throw new DomainException("Você já fez uma avaliação sobre esse livro.");

            //Regra 3: Criar Review dentro do agregado
            var review = new Review(grade, description, userId, bookId);

            _reviews.Add(review);

            // Regra 4: Recalcular média
            RecalculateAverageReview();
        }

        private void RecalculateAverageReview()
        {
            AverageReview = _reviews.Any()
                ? _reviews.Average(r => (decimal)r.Grade)
                : 0;
        }

        public void SetBookCover(byte[] bookCover)
        {
            BookCover = bookCover;
        }
    }

}
