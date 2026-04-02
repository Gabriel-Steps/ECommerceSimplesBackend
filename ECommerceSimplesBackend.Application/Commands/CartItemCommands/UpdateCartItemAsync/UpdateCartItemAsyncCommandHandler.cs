using ECommerceSimplesBackend.Application.Exceptions.CartItemExceptions;
using ECommerceSimplesBackend.Infra.Repositories.CartItemRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartItemCommands.UpdateCartItemAsync
{
    public class UpdateCartItemAsyncCommandHandler : IRequestHandler<UpdateCartItemAsyncCommand, Unit>
    {
        private readonly ICartItemRepository _repository;

        public UpdateCartItemAsyncCommandHandler(ICartItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateCartItemAsyncCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundCartItemByIdException(request.Id);
            item.Quantity = request.Quantity;

            await _repository.UpdateAsync(item, cancellationToken);
            return Unit.Value;
        }
    }
}
