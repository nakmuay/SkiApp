using SkiApp.Services.Interfaces;

namespace SkiApp.Services
{
    public class AdultsSkiLengthComputerFactory : ISkiLengthComputerFactory
    {
        public ISkiLengthComputer Create()
        {
            return new AdultsSkiLengthComputer();
        }
    }
}
