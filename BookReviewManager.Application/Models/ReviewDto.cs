using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Models
{
    public class ReviewDto
    {
        public int Id { get; init; }
        public int Grade { get; init; }
        public string Description { get; init; }
        public string UserName { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
