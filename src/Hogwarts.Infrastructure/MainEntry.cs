
using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure;
using Microsoft.EntityFrameworkCore;

using var dbContext = new HogwartsDbContext();

/* var newCourse = new Course()
{
    Id = Guid.NewGuid(),
    Name = "Muggle Research",
    Description = "The study of Muggle life and his history"
};

dbContext.Add(newCourse);
await dbContext.SaveChangesAsync(); */

/* var courses = await dbContext.Courses.Include(c => c.Professor).ToListAsync();
foreach (var course in courses)
{
    Console.WriteLine($@"Curso: {course.Id} - {course.Name} | Description: {course.Description}");
} */

