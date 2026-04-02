using ECommerceSimplesBackend.Domain.Entities;

namespace ECommerceSimplesBackend.Infra.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
