namespace Hogwarts.Domain.Entities.Primitives
{
    /// <summary>
    /// Base class for all entities in the Hogwarts domain.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public Guid Id { get; set; }
    }
}
