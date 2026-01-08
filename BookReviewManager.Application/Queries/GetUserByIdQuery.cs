using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using MediatR;

namespace BookReviewManager.Application.Queries
{
    public record GetUserByIdQuery(int Id)
    : IRequest<ResultVM<User>>;
}
