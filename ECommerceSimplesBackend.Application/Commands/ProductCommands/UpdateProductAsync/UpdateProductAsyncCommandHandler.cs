using ECommerceSimplesBackend.Application.Exceptions.ProductExceptions;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.ProductCommands.UpdateProductAsync
{
    public class UpdateProductAsyncCommandHandler : IRequestHandler<UpdateProductAsyncCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProductAsyncCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductAsyncCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundProductByIdException(request.Id);
            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
