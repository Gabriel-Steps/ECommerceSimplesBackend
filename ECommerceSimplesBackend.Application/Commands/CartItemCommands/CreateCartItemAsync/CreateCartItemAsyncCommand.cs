using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartItemCommands.CreateCartItemAsync
{
    public class CreateCartItemAsyncCommand : IRequest<Unit>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
