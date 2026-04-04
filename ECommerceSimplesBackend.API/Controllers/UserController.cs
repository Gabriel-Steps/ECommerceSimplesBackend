using ECommerceSimplesBackend.Application.Queries.UserQueries.GetUserByIdAsync;
using ECommerceSimplesBackend.Application.ViewModels.UserViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimplesBackend.API.Controllers
{
    [ApiController, Route("api/user"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetUserByIdAsyncQuery(id);
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<UserInfoViewModelDto>
            {
                Status = true,
                Message = null,
                Data = data
            });
        }
    }
}