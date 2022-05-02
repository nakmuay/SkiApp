namespace SkiApp.Services
{
    using SkiApp.Services.Interfaces;

    public class AdultsSkiLengthComputerFactory : ISkiLengthComputerFactory
    {
        public ISkiLengthComputer Create()
        {
            return new AdultsSkiLengthComputer();
        }
    }
}
