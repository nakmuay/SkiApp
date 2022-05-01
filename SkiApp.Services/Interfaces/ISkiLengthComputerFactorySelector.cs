namespace SkiApp.Services.Interfaces
{
    public interface ISkiLengthComputerFactorySelector
    {
        public ISkiLengthComputerFactory Select(int age);
    }
}
