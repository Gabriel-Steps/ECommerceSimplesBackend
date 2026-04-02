using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartItemCommands.UpdateCartItemAsync
{
    public class UpdateCartItemAsyncCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
