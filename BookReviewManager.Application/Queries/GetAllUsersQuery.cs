using BookReviewManager.Application.Models;
using MediatR;

namespace BookReviewManager.Application.Queries.UserQueries.GetAllUsers
{
    public sealed record GetAllUsersQuery()
        : IRequest<ResultVM<List<UserDto>>>;
}