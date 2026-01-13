using BookReviewManager.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries
{
    public record GetUserByEmailQuery(
     string Email,
     string Password
 ) : IRequest<ResultVM<UserDto>>;
}
