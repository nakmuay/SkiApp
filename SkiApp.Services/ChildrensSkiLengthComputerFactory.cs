namespace SkiApp.Services
{
    using SkiApp.Services.Interfaces;
    public sealed class ChildrensSkiLengthComputerFactory : ISkiLengthComputerFactory
    {
        public ISkiLengthComputer Create()
        {
            return new ChildrensSkiLengthComputer();
        }
    }
}
