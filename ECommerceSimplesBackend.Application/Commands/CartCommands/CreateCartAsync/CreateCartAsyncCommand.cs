using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.CartCommands.CreateCartAsync
{
    public class CreateCartAsyncCommand : IRequest<Unit>
    {
        public int userId { get; set; }
    }
}
