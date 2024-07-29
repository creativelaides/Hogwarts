using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Entities
{
    /// <summary>
    /// Represents a picture associated with a character in the Hogwarts domain.
    /// </summary>
    public class Picture : EntityBase
    {
        /// <summary>
        /// Gets or sets the URL of the picture.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the character associated with this picture.
        /// </summary>
        public Guid? CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the character associated with this picture.
        /// </summary>
        public Character? Character { get; set; }
    }
}
