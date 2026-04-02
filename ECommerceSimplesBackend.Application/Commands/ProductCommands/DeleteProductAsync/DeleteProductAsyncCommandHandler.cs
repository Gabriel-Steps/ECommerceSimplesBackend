using ECommerceSimplesBackend.Application.Exceptions.ProductExceptions;
using ECommerceSimplesBackend.Infra.Repositories.ProductRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.ProductCommands.DeleteProductAsync
{
    public class DeleteProductAsyncCommandHandler : IRequestHandler<DeleteProductAsyncCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public DeleteProductAsyncCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductAsyncCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundProductByIdException(request.Id);
            await _repository.DeleteAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
