﻿using SkiApp.Data.Models;
using SkiApp.Services.Interfaces;
using SkiApp.Services.Internal;

namespace SkiApp.Services
{
    public sealed class AdultsSkiLengthComputer : ISkiLengthComputer
    {
        public Either<string, SkiLengthResult> Compute(int height, SkiType type)
        {
            int skiLength = 0;
            switch (type)
            {
                case (SkiType.Classic):
                    skiLength = Math.Min(height + 20, 207);
                    break;

                case (SkiType.Freestyle):
                    if (height < 100)
                    {
                        skiLength = 100;
                    }
                    else
                    {
                        // Scale length addition linearly between 10 and 15cm in the height range 100 - 177cm.
                        skiLength = (int)(height + 10 + 0.028d * height);
                        skiLength = Math.Min(skiLength, 192);
                    }
                    break;

                default:
                    throw new NotSupportedException($"{type} is not a supported {nameof(SkiType)} value.");
            }


            return Either<string, SkiLengthResult>.Right(new SkiLengthResult(skiLength));
        }
    }
}