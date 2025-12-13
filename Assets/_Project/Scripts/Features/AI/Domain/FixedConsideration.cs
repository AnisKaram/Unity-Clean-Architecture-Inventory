namespace Project.Features.AI.Domain
{
    /// <summary>
    /// Represents only one fixed value consideration without using a curve.
    /// This is helpful when we are using a fixed value for consideration, and it will
    /// save CPU calculation.
    /// </summary>
    public class FixedConsideration : IConsideration
    {
        public float Score { get; }

        public FixedConsideration(float score)
        {
            Score = score;
        }
    }
}
