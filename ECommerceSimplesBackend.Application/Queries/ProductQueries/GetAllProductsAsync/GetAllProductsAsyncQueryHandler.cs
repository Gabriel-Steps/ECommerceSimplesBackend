using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsAsync
{
    public class GetAllProductsAsyncQueryHandler : IRequestHandler<GetAllProductsAsyncQuery, List<ProductInfoViewModelDto>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsAsyncQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductInfoViewModelDto>> Handle(GetAllProductsAsyncQuery request, CancellationToken cancellationToken)
        {
            var listProducts = await _repository.GetAllAsync(cancellationToken);
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
