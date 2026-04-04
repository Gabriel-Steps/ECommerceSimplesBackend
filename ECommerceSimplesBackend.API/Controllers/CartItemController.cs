using ECommerceSimplesBackend.Application.Commands.CartItemCommands.CartItemDeleteAsync;
using ECommerceSimplesBackend.Application.Commands.CartItemCommands.CreateCartItemAsync;
using ECommerceSimplesBackend.Application.Commands.CartItemCommands.UpdateCartItemAsync;
using ECommerceSimplesBackend.Application.Queries.CartItemQueries.GetAllCartItemsByCartIdAsync;
using ECommerceSimplesBackend.Application.ViewModels.CartItemViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimplesBackend.API.Controllers
{
    [ApiController, Route("api/cartitem"), Authorize]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCartItemAsyncCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Item adicionado ao carrinho com sucesso!",
                Data = null
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCartItemAsyncCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = null,
                Data = null
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new CartItemDeleteAsyncCommand(id);
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = null,
                Data = null
            });
        }

        [HttpGet, Route("cart/{id}")]
        public async Task<IActionResult> GetAllByCartIdAsync(int id)
        {
            var query = new GetAllCartItemsByCartIdAsyncQuery(id);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<CartItemInfoViewModelDto>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }
    }
}
