namespace SkiApp.Services
{
    using SkiApp.Data.Models;
    using SkiApp.Services.Interfaces;
    using SkiApp.Services.Internal;

    public sealed class SkiLengthService : ISkiLengthService
    {
        private ISkiLengthComputerFactorySelector _factorySelector;

        public SkiLengthService(ISkiLengthComputerFactorySelector factorySelector)
        {
            this._factorySelector = factorySelector;
        }

        public Either<string, SkiLengthResult> GetSkiLength(int age, int height, SkiType type)
        {
            var factory = this._factorySelector.Select(age);
            var computer = factory.Create();
            return computer.Compute(height, type);
        }
    }
}
