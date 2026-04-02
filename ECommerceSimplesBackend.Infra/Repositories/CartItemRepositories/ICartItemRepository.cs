using ECommerceSimplesBackend.Domain.Entities;

namespace ECommerceSimplesBackend.Infra.Repositories.CartItemRepositories
{
    public interface ICartItemRepository
    {
        public Task CreateAsync(CartItem cartItem, CancellationToken cancellationToken);
        public Task UpdateAsync(CartItem cartItem, CancellationToken cancellationToken);
        public Task DeleteAsync(CartItem cartItem, CancellationToken cancellationToken);
        public Task<List<CartItem>> GetAllCartItemsByCartId(int cartId, CancellationToken cancellationToken);
        public Task<CartItem?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
