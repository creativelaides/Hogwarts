using Hogwarts.Domain.Primitives;

namespace Hogwarts.Domain;
public class Teacher : Character
{
    public Subject? Subject { get; set; }
}