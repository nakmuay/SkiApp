namespace SkiiApp.Services.Interfaces
{
    public interface ISkiiLengthComputerFactorySelector
    {
        public ISkiiLengthComputerFactory Select(int age);
    }
}
