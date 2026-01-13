using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Models
{
    public class LoginUserResponseDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Role { get; init; }
        public string Token { get; set; }
    }
}
