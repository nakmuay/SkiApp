namespace SkiApp.Services.Interfaces
{
    using SkiApp.Data.Models;
    using SkiApp.Services.Internal;

    public interface ISkiLengthService
    {
        public Either<string, SkiLengthResult> GetSkiLength(int age, int height, SkiType type);
    }
}
