using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;

public class Student : Character
{
    public House? House { get; set;}
    
    public ICollection<Subject>? Subjects { get; set;}
    public ICollection<StudentSubject>? StudentSubjects { get; set;}
}