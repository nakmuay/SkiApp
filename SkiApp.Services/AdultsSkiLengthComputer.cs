namespace SkiApp.Services
{
    using SkiApp.Data.Models;
    using SkiApp.Services.Interfaces;
    using SkiApp.Services.Internal;

    /// <summary>
    /// Class used for computing ski length for older children and adults (older than 5 years).
    /// </summary>
    public sealed class AdultsSkiLengthComputer : ISkiLengthComputer
    {
        private const int MinSkiLength = 100;

        private const int MaxClassicSkiLength = 207;

        private const int MaxFreestyleSkiLength = 192;

        public Either<string, SkiLengthResult> Compute(int height, SkiType type)
        {
            Robustness.ValidateArgumentNonNegative(nameof(height), height);

            int skiLength = 0;
            switch (type)
            {
                case (SkiType.Classic):
                    skiLength = Math.Clamp(height + 20, MinSkiLength, MaxClassicSkiLength);
                    break;

                case (SkiType.Freestyle):
                    // Scale length addition linearly between 10 and 15cm in the height range 100 - 177cm.
                    try
                    {
                        skiLength = checked((int)(height + 10 + 0.028d * height));
                        skiLength = Math.Clamp(skiLength, MinSkiLength, MaxFreestyleSkiLength);
                    } 
                    catch(OverflowException)
                    {
                        return Either<string, SkiLengthResult>.Left("The ski length computation failed (the computed value was too large).");
                    }

                    break;


                default:
                    throw new NotSupportedException($"{type} is not a supported {nameof(SkiType)} value.");
            }


            return Either<string, SkiLengthResult>.Right(new SkiLengthResult(skiLength));
        }
    }
}
