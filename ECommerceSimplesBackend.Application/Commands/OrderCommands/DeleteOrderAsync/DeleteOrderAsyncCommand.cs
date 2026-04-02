using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.OrderCommands.DeleteOrderAsync
{
    public class DeleteOrderAsyncCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
