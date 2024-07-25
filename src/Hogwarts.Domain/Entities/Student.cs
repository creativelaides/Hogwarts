using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities;

public class Student : Character
{
    public Guid? HouseId { get; set; }
    public House? House { get; set;}
    
    public ICollection<Subject>? Subjects { get; set;}
    public ICollection<StudentSubject>? StudentSubjects { get; set;}
}