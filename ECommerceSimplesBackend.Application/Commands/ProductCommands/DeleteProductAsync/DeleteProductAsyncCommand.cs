using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.ProductCommands.DeleteProductAsync
{
    public class DeleteProductAsyncCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProductAsyncCommand(int id)
        {
            Id = id;
        }
    }
}
