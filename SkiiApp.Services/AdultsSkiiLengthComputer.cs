using SkiiApp.Data.Models;
using SkiiApp.Services.Interfaces;
using SkiiApp.Services.Internal;

namespace SkiiApp.Services
{
    public sealed class AdultsSkiiLengthComputer : ISkiiLengthComputer
    {
        public Either<string, SkiiLengthResult> Compute(int height)
        {
            return Either<string, SkiiLengthResult>.Right(new SkiiLengthResult(height + 20));
        }
    }
}
