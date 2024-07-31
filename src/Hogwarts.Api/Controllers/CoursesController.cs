﻿using Microsoft.AspNetCore.Mvc;
using MediatR;

using Hogwarts.Application.Features.CourseOperations.Commands;
using static Hogwarts.Application.Features.CourseOperations.Commands.CreateCourseCommand;

namespace Hogwarts.Api;

[ApiController]
[Route("api/courses")]
public class CoursesController: ControllerBase
{
    private readonly ISender _sender;

    public CoursesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> CreateCourse(
        [FromForm] CreateCourseRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CreateCourseCommandRequest(request);
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }
}
