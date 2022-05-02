namespace SkiApp.Services
{
    using SkiApp.Services.Interfaces;

    public sealed class AdultsSkiLengthComputerFactory : ISkiLengthComputerFactory
    {
        public ISkiLengthComputer Create()
        {
            return new AdultsSkiLengthComputer();
        }
    }
}
