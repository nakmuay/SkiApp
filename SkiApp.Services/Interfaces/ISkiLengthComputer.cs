namespace SkiApp.Services.Interfaces
{
    using SkiApp.Data.Models;
    using SkiApp.Services.Internal;

    public interface ISkiLengthComputer
    {
        public Either<string, SkiLengthResult> Compute(int height, SkiType type);
    }
}
