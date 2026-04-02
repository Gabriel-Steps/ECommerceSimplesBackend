using ECommerceSimplesBackend.Domain.Entities;

namespace ECommerceSimplesBackend.Infra.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<List<Product>> GetAllByName(string name, CancellationToken cancellationToken);
        public Task<List<Product>> GetAllByBetweenPrice(decimal minPrice, decimal maxPrice, CancellationToken cancellationToken);
        public Task CreateAsync(Product product, CancellationToken cancellationToken);
        public Task UpdateAsync(Product product, CancellationToken cancellationToken);
        public Task DeleteAsync(Product product, CancellationToken cancellationToken);
        public Task<List<Product>> GetAllProductsByCartItem(List<CartItem> listItems, CancellationToken cancellationToken);
    }
}
