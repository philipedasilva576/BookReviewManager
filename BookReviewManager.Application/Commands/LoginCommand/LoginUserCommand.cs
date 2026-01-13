using BookReviewManager.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.LoginCommand
{
    public sealed record LoginUserCommand(
     string Email,
     string Password
 ) : IRequest<ResultVM<LoginUserResponseDto>>;
}
