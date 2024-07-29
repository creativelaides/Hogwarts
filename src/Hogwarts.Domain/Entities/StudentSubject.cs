namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents the association between a student and a subject in the Hogwarts domain.
    /// </summary>
    public class StudentSubject
    {
        /// <summary>
        /// Gets or sets the identifier of the student.
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Gets or sets the student associated with this subject.
        /// </summary>
        public Student? Student { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the subject.
        /// </summary>
        public Guid SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the subject associated with this student.
        /// </summary>
        public Subject? Subject { get; set; }
    }
}
