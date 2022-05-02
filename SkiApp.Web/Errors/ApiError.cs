namespace SkiApp.Web.Errors
{
    internal class ApiError
    {
        public ApiError(string? shortMessage, string? detailedMessage)
        {
            this.ShortMessage = shortMessage;
            this.DetailedMessage = detailedMessage;
        }

        public string? ShortMessage { get; }

        public string? DetailedMessage { get; }
    }
}
