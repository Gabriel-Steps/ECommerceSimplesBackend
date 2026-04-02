using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsAsync
{
    public class GetAllProductsAsyncQuery : IRequest<List<ProductInfoViewModelDto>>{ }
}
