using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a student in the Hogwarts domain.
    /// </summary>
    public class Student : Character
    {
        /// <summary>
        /// Gets or sets the identifier of the house to which the student belongs.
        /// </summary>
        public Guid? HouseId { get; set; }

        /// <summary>
        /// Gets or sets the house associated with the student.
        /// </summary>
        public House? House { get; set; }

        /// <summary>
        /// Gets or sets the collection of subjects the student is enrolled in.
        /// </summary>
        public ICollection<Subject> Subjects { get; set; } = [];

        /// <summary>
        /// Gets or sets the collection of student-subject relationships.
        /// </summary>
        public ICollection<StudentSubject> StudentSubjects { get; set; } = [];
    }
}
