namespace SkiiApp.Services
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Interfaces;
    using SkiiApp.Services.Internal;

    public sealed class ChildrensSkiiLengthComputer : ISkiiLengthComputer
    {
        public Either<string, SkiiLengthResult> Compute(int height, SkiiType type)
        {
            // Assume minimum skii length is 1m.
            var skiiLength = Math.Max(height, 100);
            if (skiiLength > 192)
            {
                return Either<string, SkiiLengthResult>.Left("Are you sure you are 4 years or younger?");
            }

            return Either<string, SkiiLengthResult>.Right(new SkiiLengthResult(skiiLength));
        }
    }
}
