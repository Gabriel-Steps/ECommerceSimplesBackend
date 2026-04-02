using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.CartItemRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartItemCommands.CreateCartItemAsync
{
    public class CreateCartItemAsyncCommandHandler : IRequestHandler<CreateCartItemAsyncCommand, Unit>
    {
        private readonly ICartItemRepository _repository;

        public CreateCartItemAsyncCommandHandler(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCartItemAsyncCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem()
            {
                CartId = request.CartId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                ProductPrice = request.ProductPrice
            };

            await _repository.CreateAsync(cartItem, cancellationToken);
            return Unit.Value;
        }
    }
}
