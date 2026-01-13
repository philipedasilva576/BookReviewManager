using BookReviewManager.Application.Models;
using MediatR;

namespace BookReviewManager.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultVM<int>>
    {
        public CreateUserCommand(string email, string name, string password, string role)
        {
            Email = email;
            Name = name;
            Password = password;
            Role = role;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        

    }


}
