using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetProductByIdAsync
{
    public class GetProductByIdAsyncQuery : IRequest<ProductInfoViewModelDto>
    {
        public int Id { get; set; }

        public GetProductByIdAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
