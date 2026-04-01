using ECommerceSimplesBackend.Application.ViewModels.AuthViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.AuthCommands.RegisterUserAsync
{
    public class RegisterUserAsyncCommand : IRequest<UserAuthViewModelDto>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
