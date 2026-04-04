using ECommerceSimplesBackend.Application.Commands.OrderCommands.CreateOrderAsync;
using ECommerceSimplesBackend.Application.Commands.OrderCommands.DeleteOrderAsync;
using ECommerceSimplesBackend.Application.Queries.OrderQueries.GetAllOrderByUserIDAsync;
using ECommerceSimplesBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimplesBackend.API.Controllers
{
    [ApiController, Route("api/order"), Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderAsyncCommand command)
        {
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Pedido criado com sucesso",
                Data = null
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteOrderAsyncCommand(id);
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Pedido deletado com sucesso!",
                Data = null
            });
        }

        [HttpGet, Route("user/{id}")]
        public async Task<IActionResult> GetAllByUserIdAsync(int id)
        {
            var query = new GetAllOrdersByUserIdAsyncQuery(id);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<List<Order>>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }
    }
}
