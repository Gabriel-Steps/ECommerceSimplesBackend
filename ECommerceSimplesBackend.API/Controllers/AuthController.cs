using ECommerceSimplesBackend.Application.Commands.AuthCommands.RegisterUserAsync;
using ECommerceSimplesBackend.Application.Queries.AuthQueries.LoginUserAsync;
using ECommerceSimplesBackend.Application.ViewModels.AuthViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSimplesBackend.API.Controllers
{
    [ApiController, Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("register"), AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserAsyncCommand command)
        {
            var data = await _mediator.Send(command);
            return Ok(new ApiResponse<UserAuthViewModelDto>
            {
                Status = true,
                Message = "Usuário registrado com sucesso!",
                Data = data
            });
        }

        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserAsyncQuery query)
        {
            var data = await _mediator.Send(query);
            return Ok(new ApiResponse<UserAuthViewModelDto>
            {
                Status = true,
                Message = "Login efetuado com sucesso!",
                Data = data
            });
        }
    }
}
