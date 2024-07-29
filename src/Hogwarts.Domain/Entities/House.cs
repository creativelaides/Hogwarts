using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a house in the Hogwarts domain.
    /// </summary>
    public class House : EntityBase
    {
        /// <summary>
        /// Gets or sets the name of the house.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the founder of the house.
        /// </summary>
        public string? Founder { get; set; }

        /// <summary>
        /// Gets or sets the animal symbol of the house.
        /// </summary>
        public string? Animal { get; set; }

        /// <summary>
        /// Gets or sets the element associated with the house.
        /// </summary>
        public string? Element { get; set; }

        /// <summary>
        /// Gets or sets the collection of students belonging to the house.
        /// </summary>
        public ICollection<Student> Students { get; set; } = [];
    }
}
