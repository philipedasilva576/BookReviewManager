using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Models
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal AverageReview { get; set; }
        public IReadOnlyCollection<ReviewDto> Reviews { get; set; } = [];
    }
}
