using ECommerceSimplesBackend.Application.Exceptions.CartItemExceptions;
using ECommerceSimplesBackend.Infra.Repositories.CartItemRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartItemCommands.CartItemDeleteAsync
{
    public class CartItemDeleteAsyncCommandHandler : IRequestHandler<CartItemDeleteAsyncCommand, Unit>
    {
        private readonly ICartItemRepository _repository;

        public CartItemDeleteAsyncCommandHandler(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CartItemDeleteAsyncCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundCartItemByIdException(request.Id);

            await _repository.DeleteAsync(item, cancellationToken);
            return Unit.Value;
        }
    }
}
