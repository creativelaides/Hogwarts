namespace Hogwarts.Application.Features.Subjects.Commands;

public class CreateSubjectRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProfessorId { get; set; }
}