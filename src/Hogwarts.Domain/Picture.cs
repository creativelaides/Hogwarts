using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class Picture : EntityBase
{
    public string? Url { get; set; }
    public Guid? CharacterId { get; set; }
    public Character? Character { get; set; }
}