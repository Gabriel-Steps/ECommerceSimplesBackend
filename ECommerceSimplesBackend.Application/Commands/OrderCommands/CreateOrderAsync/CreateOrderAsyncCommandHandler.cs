using ECommerceSimplesBackend.Domain.Entities;
using ECommerceSimplesBackend.Infra.Repositories.OrderRepositories;
using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.OrderCommands.CreateOrderAsync
{
    public class CreateOrderAsyncCommandHandler : IRequestHandler<CreateOrderAsyncCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderAsyncCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderAsyncCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                UserId = request.UserId,
                Total = request.Total
            };

            await _repository.CreateAsync(order, cancellationToken);

            return Unit.Value;
        }
    }
}
