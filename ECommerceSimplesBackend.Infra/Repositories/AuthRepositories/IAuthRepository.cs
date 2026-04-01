using ECommerceSimplesBackend.Domain.Entities;

namespace ECommerceSimplesBackend.Infra.Repositories.AuthRepositories
{
    public interface IAuthRepository
    {
        public Task Register(User user, CancellationToken cancellationToken);
        public Task<User?> LoginUser(string email, CancellationToken cancellationToken);
    }
}
