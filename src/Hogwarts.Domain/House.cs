using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class House : EntityBase
{
    public string? Name { get; set; }
    public string? Founder { get; set; }
    public string? Animal { get; set; }
    public string? Element { get; set; }
    public ICollection<Student>? Students { get; set; }
}
