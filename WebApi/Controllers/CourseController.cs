using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;
    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateCourseCommand createCourseCommand)
    {
        CreatedCourseResponse response=await _mediator.Send(createCourseCommand);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCourseCommand deleteCourseCommand)
    {
        DeleteCourseResponse response = await _mediator.Send(deleteCourseCommand);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCourseCommand updateCourseCommand)
    {
        UpdateCourseResponse response = await _mediator.Send(updateCourseCommand);
        return Ok(response);
    }

}
