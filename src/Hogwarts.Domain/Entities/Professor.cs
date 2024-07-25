using Hogwarts.Domain.Entities.Primitives;


namespace Hogwarts.Domain.Entities;

public class Professor : Character
{
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
}