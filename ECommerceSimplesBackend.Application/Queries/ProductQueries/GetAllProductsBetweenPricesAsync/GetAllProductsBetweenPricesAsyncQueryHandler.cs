using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsBetweenPricesAsync
{
    public class GetAllProductsBetweenPricesAsyncQueryHandler : IRequestHandler<GetAllProductsBetweenPricesAsyncQuery, List<ProductInfoViewModelDto>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsBetweenPricesAsyncQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        async Task<List<ProductInfoViewModelDto>> IRequestHandler<GetAllProductsBetweenPricesAsyncQuery, List<ProductInfoViewModelDto>>.Handle(GetAllProductsBetweenPricesAsyncQuery request, CancellationToken cancellationToken)
        {
            var listProducts = await _repository.GetAllByBetweenPrice(request.minPrice, request.maxprice, cancellationToken);
            var products = listProducts
                .Select(product => new ProductInfoViewModelDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl
                }).ToList();

            return products;
        }
    }
}
