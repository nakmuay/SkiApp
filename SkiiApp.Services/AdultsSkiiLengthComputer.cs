using SkiiApp.Data.Models;
using SkiiApp.Services.Interfaces;
using SkiiApp.Services.Internal;

namespace SkiiApp.Services
{
    public sealed class AdultsSkiiLengthComputer : ISkiiLengthComputer
    {
        public Either<string, SkiiLengthResult> Compute(int height, SkiiType type)
        {
            int skiiLength = 0;
            switch (type)
            {
                case (SkiiType.Classic):
                    skiiLength = Math.Min(height + 20, 207);
                    break;

                case (SkiiType.Freestyle):
                    if (height < 100)
                    {
                        skiiLength = 100;
                    }
                    else
                    {
                        // Scale length addition linearly between 10 and 15cm in the height range 100 - 177cm.
                        skiiLength = (int)(height + 10 + 0.028d * height);
                        skiiLength = Math.Min(skiiLength, 192);
                    }
                    break;

                default:
                    throw new NotSupportedException($"{type} is not a supported {nameof(SkiiType)} value.");
            }


            return Either<string, SkiiLengthResult>.Right(new SkiiLengthResult(skiiLength));
        }
    }
}
