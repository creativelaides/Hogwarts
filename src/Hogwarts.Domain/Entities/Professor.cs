using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a professor in the Hogwarts domain.
    /// </summary>
    public class Professor : Character
    {
        /// <summary>
        /// Gets or sets the identifier of the subject taught by the professor.
        /// </summary>
        public Guid? SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the subject associated with the professor.
        /// </summary>
        public Subject? Subject { get; set; }
    }
}
