using ECommerceSimplesBackend.Application.Services;
using ECommerceSimplesBackend.Application.ViewModels.AuthViewModels;
using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.AuthRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.AuthCommands.RegisterUserAsync
{
    public class RegisterUserAsyncCommandHandler : IRequestHandler<RegisterUserAsyncCommand, UserAuthViewModelDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly PasswordService passwordService;
        private readonly TokenService tokenService;

        public RegisterUserAsyncCommandHandler(IAuthRepository authRepository, PasswordService passwordService, TokenService tokenService)
        {
            _authRepository = authRepository;
            this.passwordService = passwordService;
            this.tokenService = tokenService;
        }
        public async Task<UserAuthViewModelDto> Handle(RegisterUserAsyncCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Email = request.Email,
                Name = request.Name,
                Role = "client"
            };

            user.Password = passwordService.HashPassword(user, request.Password);

            await _authRepository.Register(user, cancellationToken);

            return new UserAuthViewModelDto()
            {
                Name = user.Name,
                Id = user.Id,
                Token = tokenService.GenerateToken(user)
            };
        }
    }
}
