namespace SkiiApp.Services.Interfaces
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Internal;

    public interface ISkiiLengthComputer
    {
        public Either<string, SkiiLengthResult> Compute(int height);
    }
}
