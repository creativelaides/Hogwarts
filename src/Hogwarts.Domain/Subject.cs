using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class Subject : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
}
