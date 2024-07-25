using Bogus;
using Hogwarts.Domain.Entities;
using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Infrastructure.Data.Seed
{
    public class InitialSeed
    {
        protected readonly Faker _f = new("es");
        public List<Student> Students { get; set; } = [];
        public List<House> Houses { get; set; } = [];
        public List<Professor> Professors { get; set; } = [];
        public List<Subject> Subjects { get; set; } = [];
        public List<Picture> Pictures { get; set; } = [];

        public void InitialSeedData()
        {
            InitialSeedHouses();
            InitialSeedStudents();
            InitialSeedSubjects();
            InitialSeedProfessors();
        }

        public void InitialSeedStudents()
        {
            var studentFaker = new Faker<Student>("es")
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Description, f => f.Lorem.Sentence())
                .RuleFor(s => s.Age, f => f.Random.Int(11, 17))
                .RuleFor(s => s.DateOfBirth, (f, s) => f.Date.Past(s.Age, DateTime.Now.AddYears(-s.Age)))
                .RuleFor(s => s.BloodStatus, f => f.PickRandom<BloodStatus>())
                .RuleFor(s => s.HouseId, f => f.PickRandom(Houses).Id)
                .RuleFor(s => s.Picture, (f, s) => new Picture
                {
                    Url = f.Image.PicsumUrl(),
                    CharacterId = s.Id,
                    Character = s
                });

            Students = studentFaker.Generate(20);

            foreach (var student in Students)
            {
                if (student.Picture != null)
                {
                    Pictures.Add(student.Picture);
                }
            }
        }


        public void InitialSeedHouses()
        {
            Houses =
            [
                new()
                {
                    Name = "Gryffindor",
                    Founder = "Godric Gryffindor",
                    Animal = "Lion",
                    Element = "Fire"
                },
                new()
                {
                    Name = "Hufflepuff",
                    Founder = "Helga Hufflepuff",
                    Animal = "Badger",
                    Element = "Earth"
                },
                new()
                {
                    Name = "Ravenclaw",
                    Founder = "Rowena Ravenclaw",
                    Animal = "Eagle",
                    Element = "Air"
                },
                new()
                {
                    Name = "Slytherin",
                    Founder = "Salazar Slytherin",
                    Animal = "Serpent",
                    Element = "Water"
                }
            ];
        }


        public void InitialSeedProfessors()
        {
            var professorFaker = new Faker<Professor>("es")
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Age, f => f.Random.Int(25, 65))
                .RuleFor(p => p.DateOfBirth, (f, p) => f.Date.Past(p.Age, DateTime.Now.AddYears(-p.Age)))
                .RuleFor(p => p.BloodStatus, f => f.PickRandom<BloodStatus>())
                .RuleFor(p => p.SubjectId, f => f.PickRandom(Subjects).Id)
                .RuleFor(p => p.Picture, (f, p) => new Picture
                {
                    Url = f.Image.PicsumUrl(),
                    CharacterId = p.Id,
                    Character = p
                });

            Professors = professorFaker.Generate(10);

            foreach (var professor in Professors)
            {
                if (professor.Picture != null)
                {
                    Pictures.Add(professor.Picture);
                }
            }
        }


        public void InitialSeedSubjects()
        {
            var subjectNames = new[]
            {
                "Potions", "Defense Against the Dark Arts", "Herbology", "Transfiguration",
                "Charms", "Astronomy", "History of Magic", "Flying", "Divination", "Arithmancy"
            };
            var subjectFaker = new Faker<Subject>("es")
                .RuleFor(s => s.Name, f => f.PickRandom(subjectNames))
                .RuleFor(s => s.Description, f => f.Lorem.Sentence());

            Subjects = subjectFaker.Generate(10);
        }
    }
}
