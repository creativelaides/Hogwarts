using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class Student : EntityBase
{
    public string? FirstName { get; set;}
    public string? LastName { get; set;}
    public int Age { get; set;}
    public DateTime DateOfBirth { get; set;}

}