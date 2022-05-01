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

        public Either<string, SkiiLengthResult> GetSkiiLength(int age, int height)
        {
            var factory = this._factorySelector.Select(age);
            var computer = factory.Create();
            return computer.Compute(height);
        }
    }

    /*
     public sealed class SkiiLengthService : ISkiiLengthService
    {
        private ISkiiLengthComputer _childrensSkiiLengthComputer;
        private ISkiiLengthComputer _adultsSkiiLengthComputer;

        public SkiiLengthService(ISkiiLengthComputer childrensSkiiLengthComputer,ISkiiLengthComputer adultsSkiiLengthComputer)
        {
            this._childrensSkiiLengthComputer = childrensSkiiLengthComputer;
            this._adultsSkiiLengthComputer = adultsSkiiLengthComputer;
        }

        public Either<string, SkiiLengthResult> GetSkiiLength(int age, int height)
        {
            var result = this.GetAgeCategory(age, height);

            return result.Match(
                left => Either<string, SkiiLengthResult>.Left(left),
                right => right.Match(
                        (height) =>
                        {
                            return Either<string, SkiiLengthResult>.Right(this._childrensSkiiLengthComputer.Compute(height));
                        },
                        (height) =>
                        {
                            return Either<string, SkiiLengthResult>.Right(this._adultsSkiiLengthComputer.Compute(height));
                        }));
        }

        private Either<string, AgeCategoryResult> GetAgeCategory(int age, int height)
        {
            if (age < 0)
            {
                return Either<string, AgeCategoryResult>.Left("Incorrect age specified.");
            }

            if (height < 0)
            {
                return Either<string, AgeCategoryResult>.Left("Incorrect height specified.");
            }

            if (age <= 4)
            {
                return Either<string, AgeCategoryResult>.Right(AgeCategoryResult.Child(height));
            }

            return Either<string, AgeCategoryResult>.Right(AgeCategoryResult.Adult(height));
        }
    }
     */
}
