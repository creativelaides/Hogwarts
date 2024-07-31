namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents the association between a student and a course in the Hogwarts domain.
    /// </summary>
    public class StudentCourse
    {
        /// <summary>
        /// Gets or sets the identifier of the student.
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Gets or sets the student associated with this course.
        /// </summary>
        public Student? Student { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the course.
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Gets or sets the course associated with this student.
        /// </summary>
        public Course? Course { get; set; }
    }
}
