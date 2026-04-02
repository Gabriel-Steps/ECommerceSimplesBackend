using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.OrderCommands.CreateOrderAsync
{
    public class CreateOrderAsyncCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }
    }
}
