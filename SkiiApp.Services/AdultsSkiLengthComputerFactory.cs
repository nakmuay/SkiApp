using SkiiApp.Services.Interfaces;

namespace SkiiApp.Services
{
    public class AdultsSkiLengthComputerFactory : ISkiLengthComputerFactory
    {
        public ISkiLengthComputer Create()
        {
            return new AdultsSkiLengthComputer();
        }
    }
}
