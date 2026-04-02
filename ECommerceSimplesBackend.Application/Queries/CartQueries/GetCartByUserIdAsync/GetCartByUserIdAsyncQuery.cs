using ECommerceSimplesBackend.Domain.Entities;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.CartQueries.GetCartByUserIdAsync
{
    public class GetCartByUserIdAsyncQuery : IRequest<Cart>
    {
        public int UserId { get; set; }

        public GetCartByUserIdAsyncQuery(int userid)
        {
            UserId = userid;
        }
    }
}
