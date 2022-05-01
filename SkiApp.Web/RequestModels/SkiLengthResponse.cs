namespace SkiApp.Web.RequestModels
{
    public sealed class SkiLengthResponse
    {
        public SkiLengthResponse(int skiLength)
        {
            SkiLength = skiLength;
        }

        public int SkiLength { get; set;  }
    }
}
