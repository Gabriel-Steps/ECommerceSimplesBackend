using ECommerceSimplesBackend.Application.Exceptions.AuthExceptions;
using ECommerceSimplesBackend.Application.Services;
using ECommerceSimplesBackend.Application.ViewModels.AuthViewModels;
using ECommerceSimplesBackend.Infra.Repositories.AuthRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.AuthCommands.LoginUserAsync
{
    public class LoginUserAsyncCommandHandler : IRequestHandler<LoginUserAsyncCommand, UserAuthViewModelDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly PasswordService passwordService;
        private readonly TokenService tokenService;
        
        public LoginUserAsyncCommandHandler(IAuthRepository authRepository, PasswordService passwordService, TokenService tokenService)
        {
            _authRepository = authRepository;
            this.passwordService = passwordService;
            this.tokenService = tokenService;
        }

        public async Task<UserAuthViewModelDto> Handle(LoginUserAsyncCommand request, CancellationToken cancellationToken)
        {
            var user = await _authRepository.LoginUser(request.Email, cancellationToken) ??
                throw new UserNotFoundByLoginException(request.Email);
            if (!passwordService.VerifyPassword(user, request.Password, user.Password))
                throw new UserPasswordIsIncorrectException(user.Email);

            return new UserAuthViewModelDto()
            {
                Name = user.Name,
                Id = user.Id,
                Token = tokenService.GenerateToken(user)
            };
        }
    }
}
