using SkiiApp.Services.Interfaces;

namespace SkiiApp.Services
{
    public class AdultsSkiiLengthComputerFactory : ISkiiLengthComputerFactory
    {
        public ISkiiLengthComputer Create()
        {
            return new AdultsSkiiLengthComputer();
        }
    }
}
