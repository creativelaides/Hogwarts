
using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure;
using Microsoft.EntityFrameworkCore;

using var dbContext = new HogwartsDbContext();




/* var newSubject = new Subject()
{
    Id = Guid.NewGuid(),
    Name = "Muggle Research",
    Description = "The study of Muggle life and his history"
};

dbContext.Add(newSubject);
await dbContext.SaveChangesAsync(); */

var subjects = await dbContext.Subjects.ToListAsync();
foreach (var subject in subjects)
{
    Console.WriteLine($"Curso: {subject.Id} - {subject.Name} | {subject.Description}");
}

