using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class Subject : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid ProfessorId { get; set; }
    public Professor? Professor { get; set; }
    
    public ICollection<Student>? Students { get; set;}
    public ICollection<StudentSubject>? StudentSubjects{ get; set; }
}
