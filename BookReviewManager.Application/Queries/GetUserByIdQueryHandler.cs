using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using BookReviewManager.Core.Repositories;
using MediatR;

namespace BookReviewManager.Application.Queries
{
    public sealed class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, ResultVM<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM<User>> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null)
                return ResultVM<User>.Error("Usuário não cadastrado.");

            return ResultVM<User>.Success(user);
        }
    }
}
