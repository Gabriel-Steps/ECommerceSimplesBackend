using ECommerceSimplesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimplesBackend.Infra.Repositories.CartItemRepositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ECommerceDbContext _context;

        public CartItemRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CartItem cartItem, CancellationToken cancellationToken)
        {
            await _context.CartItems.AddAsync(cartItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CartItem cartItem, CancellationToken cancellationToken)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CartItem>> GetAllCartItemsByCartId(int cartId, CancellationToken cancellationToken)
        {
            return await _context.CartItems
                .Where(cartItem => cartItem.CartId == cartId)
                .ToListAsync(cancellationToken);
        }

        public async Task<CartItem?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.CartItems.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(CartItem cartItem, CancellationToken cancellationToken)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
