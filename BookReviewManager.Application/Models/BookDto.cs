using BookReviewManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Models
{
    public class BookDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Author { get; init; }
        public string Publisher { get; init; }
        public GenreEnum Genre { get; init; }
        public int PublishYear { get; init; }
        public int PageCount { get; init; }
        public decimal AverageReview { get; init; }
        public IReadOnlyCollection<ReviewDto> Reviews { get; init; }
    }
}
