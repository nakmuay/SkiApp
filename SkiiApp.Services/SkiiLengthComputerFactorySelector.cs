using SkiiApp.Services.Interfaces;

namespace SkiiApp.Services
{
    public sealed class SkiiLengthComputerFactorySelector : ISkiiLengthComputerFactorySelector
    {
        private readonly ISkiiLengthComputerFactory _childrensSkiiLengthFactory;
        private readonly ISkiiLengthComputerFactory _adultsSkiiLengthFactory;

        public SkiiLengthComputerFactorySelector(ISkiiLengthComputerFactory childrensSkiiLengthFactory, ISkiiLengthComputerFactory adultsSkiiLengthFactory)
        {
            this._childrensSkiiLengthFactory = childrensSkiiLengthFactory;
            this._adultsSkiiLengthFactory = adultsSkiiLengthFactory;
        }

        public ISkiiLengthComputerFactory Select(int age)
        {
            if (age <= 4)
            {
                return this._childrensSkiiLengthFactory;
            }

            return this._adultsSkiiLengthFactory;
        }
    }
}
