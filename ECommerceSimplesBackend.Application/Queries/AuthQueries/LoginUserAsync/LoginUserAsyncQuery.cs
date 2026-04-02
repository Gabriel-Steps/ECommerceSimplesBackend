using ECommerceSimplesBackend.Application.ViewModels.AuthViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.AuthQueries.LoginUserAsync
{
    public class LoginUserAsyncQuery : IRequest<UserAuthViewModelDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
