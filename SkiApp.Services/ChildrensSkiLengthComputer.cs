namespace SkiApp.Services
{
    using SkiApp.Data.Models;
    using SkiApp.Services.Interfaces;
    using SkiApp.Services.Internal;

    /// <summary>
    /// Class used for computing ski length for young children (age 0 - 4 years).
    /// </summary>
    public sealed class ChildrensSkiLengthComputer : ISkiLengthComputer
    {
        private const int MinSkiLength = 100;

        public Either<string, SkiLengthResult> Compute(int height, SkiType type)
        {
            Robustness.ValidateArgumentNonNegative(nameof(height), height);

            // Assume minimum ski length is 1m.
            var skiLength = Math.Max(height, MinSkiLength);
            if (skiLength > 192)
            {
                return Either<string, SkiLengthResult>.Left("Are you sure you are 4 years or younger?");
            }

            return Either<string, SkiLengthResult>.Right(new SkiLengthResult(skiLength));
        }
    }
}
