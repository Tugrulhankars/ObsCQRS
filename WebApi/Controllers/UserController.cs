using Application.Features.Users.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        CreatedUserResponse response=await _mediator.Send(command);
        return Ok(response);
    }
}
