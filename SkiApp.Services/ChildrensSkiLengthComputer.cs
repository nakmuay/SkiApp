namespace SkiApp.Services
{
    using SkiApp.Data.Models;
    using SkiApp.Services.Interfaces;
    using SkiApp.Services.Internal;

    public sealed class ChildrensSkiLengthComputer : ISkiLengthComputer
    {
        public Either<string, SkiLengthResult> Compute(int height, SkiType type)
        {
            // Assume minimum ski length is 1m.
            var skiLength = Math.Max(height, 100);
            if (skiLength > 192)
            {
                return Either<string, SkiLengthResult>.Left("Are you sure you are 4 years or younger?");
            }

            return Either<string, SkiLengthResult>.Right(new SkiLengthResult(skiLength));
        }
    }
}
