namespace Project.Features.AI.Domain
{
    /// <summary>
    /// Represents a single factor (Hunger, Distance, Safety, etc...).
    /// </summary>
    public interface IConsideration
    {
        public float Score { get; } // Returns the normalized value how important this factor is right now
    }
}