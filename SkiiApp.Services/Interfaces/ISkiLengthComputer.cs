namespace SkiiApp.Services.Interfaces
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Internal;

    public interface ISkiLengthComputer
    {
        public Either<string, SkiLengthResult> Compute(int height, SkiType type);
    }
}
