using ECommerceSimplesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimplesBackend.Infra.Repositories.CartRepositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ECommerceDbContext _context;

        public CartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Cart cart, CancellationToken cancellationToken)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Cart?> GetCartByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _context.Carts.SingleOrDefaultAsync(cart => cart.UserId == userId, cancellationToken);
        }
    }
}
