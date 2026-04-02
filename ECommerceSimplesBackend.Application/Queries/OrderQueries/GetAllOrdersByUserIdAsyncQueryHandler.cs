using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.OrderRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.OrderQueries
{
    public class GetAllOrdersByUserIdAsyncQueryHandler : IRequestHandler<GetAllOrdersByUserIdAsyncQuery, List<Order>>
    {
        private readonly IOrderRepository _repository;

        public GetAllOrdersByUserIdAsyncQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> Handle(GetAllOrdersByUserIdAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllOrdersByUserIdAsync(request.Id, cancellationToken);
        }
    }
}
