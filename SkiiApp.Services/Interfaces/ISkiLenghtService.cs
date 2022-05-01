namespace SkiiApp.Services.Interfaces
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Internal;

    public interface ISkiLengthService
    {
        public Either<string, SkiLengthResult> GetSkiLength(int age, int height, SkiType type);
    }
}
