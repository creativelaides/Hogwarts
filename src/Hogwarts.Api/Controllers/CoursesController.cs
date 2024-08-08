using Microsoft.AspNetCore.Mvc;
using MediatR;

using Hogwarts.Application.Features.CourseOperations.Commands;
using static Hogwarts.Application.Features.CourseOperations.Commands.CreateCourseCommand;
using static Hogwarts.Application.Features.CourseOperations.Queries.ReportCourseQuery;
using Hogwarts.Application.Core;

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
    public async Task<ActionResult<Result<Guid>>> CreateCourse(
        [FromForm] CreateCourseRequest request,
        CancellationToken cancellationToken
    )
    {
        // throw new Exception("Prueba de Exception de Middleware");
        var command = new CreateCourseCommandRequest(request);
        return await _sender.Send(command, cancellationToken);
    }

    [HttpGet("report")]
    public async Task<IActionResult> CsvReport(CancellationToken cancellationToken){
        var query = new ReportCourseQueryRequest();
        var result = await _sender.Send(query, cancellationToken);
        byte[] bytes = result.ToArray();

        return File(bytes, "text/csv", "report.csv");
    }
}
