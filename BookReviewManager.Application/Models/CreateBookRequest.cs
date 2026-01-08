using BookReviewManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Models
{
    public class CreateBookRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public GenreEnum Genre { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
    }
}
