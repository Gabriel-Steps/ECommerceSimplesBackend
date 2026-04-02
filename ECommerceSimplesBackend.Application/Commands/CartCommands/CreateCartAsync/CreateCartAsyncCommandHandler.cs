using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.CartRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartCommands.CreateCartAsync
{
    public class CreateCartAsyncCommandHandler : IRequestHandler<CreateCartAsyncCommand, Unit>
    {
        private readonly ICartRepository _repository;

        public CreateCartAsyncCommandHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCartAsyncCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart()
            {
                UserId = request.userId
            };

            await _repository.CreateAsync(cart, cancellationToken);
            return Unit.Value;
        }
    }
}
