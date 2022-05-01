namespace SkiiApp.Services
{
    using SkiiApp.Services.Interfaces;
    public sealed class ChildrensSkiLengthComputerFactory : ISkiLengthComputerFactory
    {
        public ISkiLengthComputer Create()
        {
            return new ChildrensSkiLengthComputer();
        }
    }
}
