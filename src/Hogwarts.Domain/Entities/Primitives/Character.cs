namespace Hogwarts.Domain.Entities.Primitives;

public abstract class Character: EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodStatus BloodStatus { get; set; }
    public Guid PictureId { get; set; }
    public Picture? Picture { get; set; }

}