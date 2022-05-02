namespace SkiApp.Services
{
    using SkiApp.Services.Interfaces;
    using SkiApp.Services.Internal;

    public sealed class SkiLengthComputerFactorySelector : ISkiLengthComputerFactorySelector
    {
        private readonly ISkiLengthComputerFactory _childrensSkiLengthFactory;
        private readonly ISkiLengthComputerFactory _adultsSkiLengthFactory;

        public SkiLengthComputerFactorySelector(ISkiLengthComputerFactory childrensSkiLengthFactory, ISkiLengthComputerFactory adultsSkiLengthFactory)
        {
            this._childrensSkiLengthFactory = childrensSkiLengthFactory;
            this._adultsSkiLengthFactory = adultsSkiLengthFactory;
        }

        public ISkiLengthComputerFactory Select(int age)
        {
            Robustness.ValidateArgumentNonNegative(nameof(age), age);

            return age <= 4 ? this._childrensSkiLengthFactory : this._adultsSkiLengthFactory;
        }
    }
}
