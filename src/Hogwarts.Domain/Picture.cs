using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class Picture : EntityBase
{
    public string? Url { get; set; }
}