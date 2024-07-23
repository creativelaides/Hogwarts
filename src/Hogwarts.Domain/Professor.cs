using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;
public class Professor : Character
{
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
}