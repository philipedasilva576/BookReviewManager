using BookReviewManager.Application.Models;
using BookReviewManager.Application.Queries.UserQueries.GetAllUsers;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Queries
{
    public class GetAllUsersQueryHandler
       : IRequestHandler<GetAllUsersQuery, ResultVM<List<UserDto>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM<List<UserDto>>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                CreatedAt = u.CreatedAt
            }).ToList();

            return ResultVM<List<UserDto>>.Success(result);
        }
    }
}
