using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Password { get; set; }
    }
}
