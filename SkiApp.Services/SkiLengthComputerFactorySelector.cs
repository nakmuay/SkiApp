namespace SkiApp.Services
{
    using SkiApp.Services.Interfaces;
    using SkiApp.Services.Internal;

    /// <summary>
    /// Class used selecting computer factories.
    /// </summary>
    public sealed class SkiLengthComputerFactorySelector : ISkiLengthComputerFactorySelector
    {
        // This class is actually a factory-factory but that name doesn't really make sense.

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
