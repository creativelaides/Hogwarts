using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;
public class Teacher : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}