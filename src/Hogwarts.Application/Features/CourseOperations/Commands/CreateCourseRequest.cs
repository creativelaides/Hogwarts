namespace Hogwarts.Application.Features.CourseOperations.Commands;

public class CreateCourseRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProfessorId { get; set; }
}