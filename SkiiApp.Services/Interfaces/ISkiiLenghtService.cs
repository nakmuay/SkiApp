namespace SkiiApp.Services.Interfaces
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Internal;

    public interface ISkiiLengthService
    {
        public Either<string, SkiiLengthResult> GetSkiiLength(int age, int height);
    }
}
