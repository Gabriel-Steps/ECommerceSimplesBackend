using ECommerceSimplesBackend.Application.ViewModels.AuthViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.AuthCommands.LoginUserAsync
{
    public class LoginUserAsyncCommand : IRequest<UserAuthViewModelDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
