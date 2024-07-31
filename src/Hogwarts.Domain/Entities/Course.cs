using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a course in the Hogwarts domain.
    /// </summary>
    public class Course : EntityBase
    {
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the course.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the professor associated with this course.
        /// </summary>
        public Guid? ProfessorId { get; set; }

        /// <summary>
        /// Gets or sets the professor associated with this course.
        /// </summary>
        public Professor? Professor { get; set; }

        /// <summary>
        /// Gets or sets the collection of students enrolled in this course.
        /// </summary>
        public ICollection<Student> Students { get; set; } = [];

        /// <summary>
        /// Gets or sets the collection of student-course relationships.
        /// </summary>
        public ICollection<StudentCourse> StudentCourses { get; set; } = [];
    }
}
