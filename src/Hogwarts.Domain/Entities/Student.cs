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
        /// Gets or sets the collection of courses the student is enrolled in.
        /// </summary>
        public ICollection<Course> Courses { get; set; } = [];

        /// <summary>
        /// Gets or sets the collection of student-course relationships.
        /// </summary>
        public ICollection<StudentCourse> StudentCourses { get; set; } = [];
    }
}
