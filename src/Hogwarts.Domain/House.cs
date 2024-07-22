using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class House : EntityBase
{
    public string? Name { get; set; }
    public string? Founder { get; set; }

}
