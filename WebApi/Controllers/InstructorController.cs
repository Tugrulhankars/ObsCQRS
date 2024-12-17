using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Students.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IMediator _mediator;
    public InstructorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateInstructorCommand createInstructorCommand)
    {
        CreatedInstructorResponse reponse =await  _mediator.Send(createInstructorCommand);
        return Ok(reponse);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteInstructorCommand deleteInstructorCommand)
    {
        DeleteInstructorResponse response = await _mediator.Send(deleteInstructorCommand);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateInstructorCommand updateInstructorCommand)
    {
        UpdateInstructorResponse response = await _mediator.Send(updateInstructorCommand);
        return Ok(response);
    }
}
