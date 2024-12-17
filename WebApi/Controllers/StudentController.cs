using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetList;
using Application.Tools.Pagination;
using Application.Tools.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;
    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateStudentCommand createStudentCommand)
    {
        CreatedStudentResponse response=await _mediator.Send(createStudentCommand);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeletedStudentCommand deletedStudentCommand)
    {
        DeletedStudentResponse response=await _mediator.Send(deletedStudentCommand);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
    {
        UpdateStudentResponse response = await _mediator.Send(updateStudentCommand);
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentQuery getListStudentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentDto> response = await _mediator.Send(getListStudentQuery);
        return Ok(response);
    }
}
