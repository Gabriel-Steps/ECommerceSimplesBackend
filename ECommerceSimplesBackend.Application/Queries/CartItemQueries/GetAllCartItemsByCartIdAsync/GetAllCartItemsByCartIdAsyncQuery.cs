using ECommerceSimplesBackend.Application.ViewModels.CartItemViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.CartItemQueries.GetAllCartItemsByCartIdAsync
{
    public class GetAllCartItemsByCartIdAsyncQuery : IRequest<List<CartItemInfoViewModelDto>>
    {
        public int Id { get; set; }

        public GetAllCartItemsByCartIdAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
