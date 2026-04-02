using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductByNameAsync
{
    public class GetAllProductByNameAsyncQuery : IRequest<List<ProductInfoViewModelDto>>
    {
        public string Name { get; set; } = null!;

        public GetAllProductByNameAsyncQuery(string name)
        {
            Name = name;
        }
    }
}
