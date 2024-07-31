using Bogus;
using Hogwarts.Domain.Entities;
using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Infrastructure.Data.Seed;

/// <summary>
/// Initial seed data for the Hogwarts application.
/// </summary>
/// <remarks>
/// This class contains methods to generate fake data for the Hogwarts application.
/// </remarks>
/// <example>
/// <code>
/// var initialSeed = new InitialSeed();
/// initialSeed.InitialSeedData();
/// </code>
/// </example>
/// <seealso cref="InitialSeedHouses"/>
/// <seealso cref="InitialSeedCourses"/>
/// <seealso cref="InitialSeedPictures"/>
/// <seealso cref="InitialSeedStudents"/>
/// <seealso cref="InitialSeedProfessors"/>

internal class InitialSeed
{
    public List<Student> Students { get; set; } = [];
    public List<House> Houses { get; set; } = [];
    public List<Professor> Professors { get; set; } = [];
    public List<Course> Courses { get; set; } = [];
    public List<Picture> Pictures { get; set; } = [];

    public void InitialSeedData()
    {
        InitialSeedHouses();
        InitialSeedPictures();
        InitialSeedStudents();
        InitialSeedProfessors();
        InitialSeedCourses();
        AssignCharacterIdsToPictures();
        AssignProfessorIdsToCourses();
    }

    public void InitialSeedPictures()
    {
        var pictureFaker = new Faker<Picture>("es")
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Url, f => f.Image.PicsumUrl());

        Pictures = pictureFaker.Generate(30);
    }

    public void InitialSeedStudents()
    {
        var studentFaker = new Faker<Student>("es")
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.FirstName, f => f.Name.FirstName())
            .RuleFor(s => s.LastName, f => f.Name.LastName())
            .RuleFor(s => s.Description, f => f.Lorem.Sentence())
            .RuleFor(s => s.Age, f => f.Random.Int(11, 17))
            .RuleFor(s => s.DateOfBirth, (f, s) => f.Date.Past(s.Age, DateTime.UtcNow.AddYears(-s.Age)))
            .RuleFor(s => s.BloodStatus, f => f.PickRandom<BloodStatus>())
            .RuleFor(s => s.HouseId, f => f.PickRandom(Houses).Id);

        Students = studentFaker.Generate(20);
    }

    public void InitialSeedProfessors()
    {
        var professorFaker = new Faker<Professor>("es")
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.Age, f => f.Random.Int(25, 65))
            .RuleFor(p => p.DateOfBirth, (f, p) => f.Date.Past(p.Age, DateTime.UtcNow.AddYears(-p.Age)))
            .RuleFor(p => p.BloodStatus, f => f.PickRandom<BloodStatus>());

        Professors = professorFaker.Generate(10);
    }

    public void AssignCharacterIdsToPictures()
    {
        var characters = Students.Cast<Character>().Concat(Professors.Cast<Character>()).ToList();
        if (characters.Count > Pictures.Count)
        {
            throw new InvalidOperationException("Not enough pictures to assign to each character.");
        }

        for (int i = 0; i < characters.Count; i++)
        {
            Pictures[i].CharacterId = characters[i].Id;
            if (characters[i] is Student student)
            {
                student.PictureId = Pictures[i].Id;
            }
            else if (characters[i] is Professor professor)
            {
                professor.PictureId = Pictures[i].Id;
            }
        }
    }

    public void AssignProfessorIdsToCourses()
    {
        if (Courses.Count != Professors.Count)
        {
            throw new InvalidOperationException("Courses and Professors count mismatch.");
        }

        for (int i = 0; i < Courses.Count; i++)
        {
            Courses[i].ProfessorId = Professors[i].Id;
            Professors[i].CourseId = Courses[i].Id;
        }
    }

    public void InitialSeedHouses()
    {
        Houses =
        [
            new() {
                Id = Guid.NewGuid(),
                Name = "Gryffindor",
                Founder = "Godric Gryffindor",
                Animal = "Lion",
                Element = "Fire"
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Hufflepuff",
                Founder = "Helga Hufflepuff",
                Animal = "Badger",
                Element = "Earth"
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Ravenclaw",
                Founder = "Rowena Ravenclaw",
                Animal = "Eagle",
                Element = "Air"
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Slytherin",
                Founder = "Salazar Slytherin",
                Animal = "Serpent",
                Element = "Water"
            }
        ];
    }

    public void InitialSeedCourses()
    {
        var CourseNames = new[]
        {
            "Potions", "Defense Against the Dark Arts", "Herbology", "Transfiguration",
            "Charms", "Astronomy", "History of Magic", "Flying", "Divination", "Arithmancy"
        };

        var courseFaker = new Faker<Course>("es")
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.PickRandom(CourseNames))
            .RuleFor(c => c.Description, f => f.Lorem.Sentence());

        Courses = courseFaker.Generate(10);

        // Assign Professor IDs to Courses and Course IDs to Professors
        for (int i = 0; i < Courses.Count; i++)
        {
            Courses[i].ProfessorId = Professors[i].Id;
            Professors[i].CourseId = Courses[i].Id;
        }
    }
}
