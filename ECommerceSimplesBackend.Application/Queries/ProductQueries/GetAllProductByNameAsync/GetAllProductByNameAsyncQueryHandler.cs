using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductByNameAsync
{
    public class GetAllProductByNameAsyncQueryHandler : IRequestHandler<GetAllProductByNameAsyncQuery, List<ProductInfoViewModelDto>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductByNameAsyncQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductInfoViewModelDto>> Handle(GetAllProductByNameAsyncQuery request, CancellationToken cancellationToken)
        {
            var listProducts = await _repository.GetAllByName(request.Name, cancellationToken);
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
