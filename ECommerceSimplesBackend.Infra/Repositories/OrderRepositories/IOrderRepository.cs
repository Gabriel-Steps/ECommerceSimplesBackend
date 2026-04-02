using ECommerceSimplesBackend.Domain.Entities;

namespace ECommerceSimplesBackend.Infra.Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        public Task CreateAsync(Order order, CancellationToken cancellationToken);
        public Task DeleteAsync(Order order, CancellationToken cancellationToken);
        public Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<List<Order>> GetAllOrdersByUserIdAsync(int id, CancellationToken cancellationToken);
    }
}
