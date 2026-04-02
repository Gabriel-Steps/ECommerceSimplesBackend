using ECommerceSimplesBackend.Application.Exceptions.OrderExceptions;
using ECommerceSimplesBackend.Infra.Repositories.OrderRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSimplesBackend.Application.Commands.OrderCommands.DeleteOrderAsync
{
    public class DeleteOrderAsyncCommandHandler : IRequestHandler<DeleteOrderAsyncCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderAsyncCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteOrderAsyncCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new NotFoundOrderByIdException(request.Id);

            await _repository.DeleteAsync(order, cancellationToken);
            return Unit.Value;
        }
    }
}
