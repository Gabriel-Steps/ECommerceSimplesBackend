using ECommerceSimplesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimplesBackend.Infra.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllByBetweenPrice(decimal minPrice, decimal maxPrice, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(product => product.Price >= minPrice && product.Price <= maxPrice)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllByName(string name, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(product => product.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllProductsByCartItem(List<CartItem> listItems, CancellationToken cancellationToken)
        {
            var productIds = listItems.Select(i => i.ProductId).Distinct().ToList();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync(cancellationToken);

            return products;
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.SingleOrDefaultAsync(product => product.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
