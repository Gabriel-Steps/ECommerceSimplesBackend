using ECommerceSimplesBackend.Application.Exceptions.UserExceptions;
using ECommerceSimplesBackend.Application.ViewModels.UserViewModels;
using ECommerceSimplesBackend.Infra.Repositories.UserRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.UserQueries.GetUserByIdAsync
{
    public class GetUserByIdAsyncQueryHandler : IRequestHandler<GetUserByIdAsyncQuery, UserInfoViewModelDto>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdAsyncQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserInfoViewModelDto> Handle(GetUserByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundUserByIdException(request.Id);

            return new UserInfoViewModelDto()
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
