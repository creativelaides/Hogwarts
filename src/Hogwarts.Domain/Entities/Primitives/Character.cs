namespace Hogwarts.Domain.Entities.Primitives
{
    /// <summary>
    /// Represents a character in the Hogwarts domain.
    /// </summary>
    public abstract class Character : EntityBase
    {
        /// <summary>
        /// Gets or sets the first name of the character.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the character.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets a description of the character.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the age of the character.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the character.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the blood status of the character.
        /// </summary>
        public BloodStatus BloodStatus { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the picture associated with the character.
        /// </summary>
        public Guid PictureId { get; set; }

        /// <summary>
        /// Gets or sets the picture associated with the character.
        /// </summary>
        public Picture? Picture { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        protected Character() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class with specific values.
        /// </summary>
        /// <param name="firstName">The first name of the character.</param>
        /// <param name="lastName">The last name of the character.</param>
        /// <param name="description">A description of the character.</param>
        /// <param name="age">The age of the character.</param>
        /// <param name="dateOfBirth">The date of birth of the character.</param>
        /// <param name="bloodStatus">The blood status of the character.</param>
        /// <param name="pictureId">The identifier for the picture associated with the character.</param>
        /// <param name="picture">The picture associated with the character.</param>
        protected Character(string? firstName, string? lastName, string? description, int age, DateTime dateOfBirth, BloodStatus bloodStatus, Guid pictureId, Picture? picture)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Age = age;
            DateOfBirth = dateOfBirth;
            BloodStatus = bloodStatus;
            PictureId = pictureId;
            Picture = picture;
        }
    }
}
