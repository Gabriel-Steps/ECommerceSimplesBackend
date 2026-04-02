using ECommerceSimplesBackend.Domain.Entities;

namespace ECommerceSimplesBackend.Infra.Repositories.CartRepositories
{
    public interface ICartRepository
    {
        public Task CreateAsync(Cart cart, CancellationToken cancellationToken);
        public Task<Cart?> GetCartByUserId(int userId, CancellationToken cancellationToken);
    }
}
