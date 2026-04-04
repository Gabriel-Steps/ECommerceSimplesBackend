using ECommerceSimplesBackend.Application.Commands.ProductCommands.CreateProductAsync;
using ECommerceSimplesBackend.Application.Commands.ProductCommands.DeleteProductAsync;
using ECommerceSimplesBackend.Application.Commands.ProductCommands.UpdateProductAsync;
using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductByNameAsync;
using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsAsync;
using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetAllProductsBetweenPricesAsync;
using ECommerceSimplesBackend.Application.Queries.ProductQueries.GetProductByIdAsync;
using ECommerceSimplesBackend.Application.ViewModels.ProductViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimplesBackend.API.Controllers
{
    [ApiController, Route("api/product"), Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductAsyncCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Produto criado com sucesso!",
                Data = null
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductAsyncCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Produto atualizado com sucesso!",
                Data = null
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteProductAsyncCommand(id);
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Produto deletado com sucesso!",
                Data = null
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllProductsAsyncQuery();
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<ProductInfoViewModelDto>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetProductByIdAsyncQuery(id);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<ProductInfoViewModelDto>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("name/{name}")]
        public async Task<IActionResult> GetAllByNameAsync(string name)
        {
            var query = new GetAllProductByNameAsyncQuery(name);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<ProductInfoViewModelDto>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }

        [HttpGet, Route("price")]
        public async Task<IActionResult> GetAllBetweenPricesAsync([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var query = new GetAllProductsBetweenPricesAsyncQuery(minPrice, maxPrice);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<ProductInfoViewModelDto>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }
    }
}