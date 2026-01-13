using BookReviewManager.Application.Models;
using BookReviewManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries
{
    public class GetUserByEmailQueryHandler
     : IRequestHandler<GetUserByEmailQuery, ResultVM<UserDto>>
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultVM<UserDto>> Handle(
            GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _repository
                .GetByEmailAsync(request.Email, request.Password);

            if (user is null)
                return ResultVM<UserDto>.Error("Usuário ou senha inválidos.");

            var dto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            return ResultVM<UserDto>.Success(dto);
        }
    }
}
