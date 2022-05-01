namespace SkiiApp.Services
{
    using SkiiApp.Services.Interfaces;
    public sealed class ChildrensSkiiLengthComputerFactory : ISkiiLengthComputerFactory
    {
        public ISkiiLengthComputer Create()
        {
            return new ChildrensSkiiLengthComputer();
        }
    }
}
