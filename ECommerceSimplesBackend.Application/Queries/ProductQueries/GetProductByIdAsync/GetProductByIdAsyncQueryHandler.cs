using ECommerceSimplesBackend.Application.Exceptions.ProductExceptions;
using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetProductByIdAsync
{
    public class GetProductByIdAsyncQueryHandler : IRequestHandler<GetProductByIdAsyncQuery, ProductInfoViewModelDto>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdAsyncQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        } 

        public async Task<ProductInfoViewModelDto> Handle(GetProductByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundProductByIdException(request.Id);

            return new ProductInfoViewModelDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
