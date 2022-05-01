using SkiiApp.Services.Interfaces;

namespace SkiiApp.Services
{
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
            if (age <= 4)
            {
                return this._childrensSkiLengthFactory;
            }

            return this._adultsSkiLengthFactory;
        }
    }
}
