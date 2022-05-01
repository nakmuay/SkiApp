namespace SkiiApp.Services
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Interfaces;
    using SkiiApp.Services.Internal;

    public sealed class ChildrensSkiiLengthComputer : ISkiiLengthComputer
    {
        public Either<string, SkiiLengthResult> Compute(int height, SkiiType type)
        {
            return Either<string, SkiiLengthResult>.Right(new SkiiLengthResult(height + 10));
        }
    }
}
