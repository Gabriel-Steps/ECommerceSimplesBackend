using MediatR;

namespace ECommerceSimplesBackend.Application.Commands.ProductCommands.CreateProductAsync
{
    public class CreateProductAsyncCommand : IRequest<Unit>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
