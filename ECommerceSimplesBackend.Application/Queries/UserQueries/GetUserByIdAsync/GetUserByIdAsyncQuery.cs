using ECommerceSimplesBackend.Application.ViewModels.UserViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.UserQueries.GetUserByIdAsync
{
    public class GetUserByIdAsyncQuery : IRequest<UserInfoViewModelDto>
    {
        public int Id { get; set; }

        public GetUserByIdAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
