using ECommerceSimplesBackend.Domain.Entities;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.OrderQueries.GetAllOrderByUserIDAsync
{
    public class GetAllOrdersByUserIdAsyncQuery : IRequest<List<Order>>
    {
        public int Id { get; set; }

        public GetAllOrdersByUserIdAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
