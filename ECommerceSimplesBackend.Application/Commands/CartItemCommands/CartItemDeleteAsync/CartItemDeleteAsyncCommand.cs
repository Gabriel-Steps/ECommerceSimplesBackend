using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartItemCommands.CartItemDeleteAsync
{
    public class CartItemDeleteAsyncCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public CartItemDeleteAsyncCommand(int id)
        {
            Id = id;
        }
    }
}
