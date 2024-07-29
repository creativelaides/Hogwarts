namespace Hogwarts.Domain.Entities.Primitives
{
    /// <summary>
    /// Represents the blood status of a magical person in the wizarding world of Harry Potter.
    /// </summary>
    public enum BloodStatus
    {
        /// <summary>
        /// Pure-blood: A witch or wizard with only magical ancestry.
        /// </summary>
        Pure,

        /// <summary>
        /// Half-blood: A witch or wizard with both magical and Muggle ancestry.
        /// </summary>
        Half,

        /// <summary>
        /// Muggle: A non-magical person born to non-magical parents.
        /// </summary>
        Muggle,

        /// <summary>
        /// Squib: A non-magical person born to magical parents.
        /// </summary>
        Squib,

        /// <summary>
        /// Hybrid: A witch or wizard with mixed magical and non-magical ancestry (this term might not be canonical, make sure it's what you intend to use).
        /// </summary>
        Hybrid
    }
}
