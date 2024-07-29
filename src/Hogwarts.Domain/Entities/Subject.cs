using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a subject in the Hogwarts domain.
    /// </summary>
    public class Subject : EntityBase
    {
        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the subject.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the professor associated with this subject.
        /// </summary>
        public Guid? ProfessorId { get; set; }

        /// <summary>
        /// Gets or sets the professor associated with this subject.
        /// </summary>
        public Professor? Professor { get; set; }

        /// <summary>
        /// Gets or sets the collection of students enrolled in this subject.
        /// </summary>
        public ICollection<Student> Students { get; set; } = [];

        /// <summary>
        /// Gets or sets the collection of student-subject relationships.
        /// </summary>
        public ICollection<StudentSubject> StudentSubjects { get; set; } = [];
    }
}
