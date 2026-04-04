using ECommerceSimplesBackend.Application.Commands.CartCommands.CreateCartAsync;
using ECommerceSimplesBackend.Application.Queries.CartQueries.GetCartByUserIdAsync;
using ECommerceSimplesBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimplesBackend.API.Controllers
{
    [ApiController, Route("api/cart"), Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCartAsyncCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = null,
                Data = null
            });
        }

        [HttpGet, Route("user/{userId}")]
        public async Task<IActionResult> GetByUserIdAsync(int userId)
        {
            var query = new GetCartByUserIdAsyncQuery(userId);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<Cart>
            {
                Status = true,
                Message = null,
                Data = null
            });
        }
    }
}
