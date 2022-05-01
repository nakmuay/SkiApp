namespace SkiiApp.Services
{
    using SkiiApp.Data.Models;
    using SkiiApp.Services.Interfaces;
    using SkiiApp.Services.Internal;

    public sealed class SkiiLengthService : ISkiiLengthService
    {
        private ISkiiLengthComputerFactorySelector _factorySelector;

        public SkiiLengthService(ISkiiLengthComputerFactorySelector factorySelector)
        {
            this._factorySelector = factorySelector;
        }

        public Either<string, SkiiLengthResult> GetSkiiLength(int age, int height, SkiiType type)
        {
            var factory = this._factorySelector.Select(age);
            var computer = factory.Create();
            return computer.Compute(height, type);
        }
    }
}
