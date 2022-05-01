namespace SkiiApp.Web.RequestModels
{
    public sealed class SkiiLengthResponse
    {
        public SkiiLengthResponse(int skiLength)
        {
            SkiLength = skiLength;
        }

        public int SkiLength { get; set;  }
    }
}
