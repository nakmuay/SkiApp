namespace SkiiApp.Web.RequestModels
{
    public sealed class SkiiLengthResponse
    {
        public SkiiLengthResponse(int skiiLength)
        {
            SkiiLength = skiiLength;
        }

        public int SkiiLength { get; set;  }
    }
}
