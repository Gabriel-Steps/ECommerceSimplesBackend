using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSimplesBackend.Application.Commands.ProductCommands.CreateProductAsync
{
    public class CreateProductAsyncCommandHandler : IRequestHandler<CreateProductAsyncCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public CreateProductAsyncCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductAsyncCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            };

            await _repository.CreateAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
