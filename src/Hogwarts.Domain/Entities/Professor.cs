using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a professor in the Hogwarts domain.
    /// </summary>
    public class Professor : Character
    {
        /// <summary>
        /// Gets or sets the identifier of the course taught by the professor.
        /// </summary>
        public Guid? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the course associated with the professor.
        /// </summary>
        public Course? Course { get; set; }
    }
}
