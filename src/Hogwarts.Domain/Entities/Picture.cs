using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities;

public class Picture : EntityBase
{
    public string? Url { get; set; }
    public Guid? CharacterId { get; set; }
    public Character? Character { get; set; }
}