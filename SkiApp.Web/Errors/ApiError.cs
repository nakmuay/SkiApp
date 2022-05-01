namespace SkiApp.Web.Errors
{
    internal sealed class ApiError
    {
        public ApiError(string parameterName, string? shortMessage, string? detailedMessage)
        {
            this.ParameterName = parameterName;
            this.ShortMessage = shortMessage;
            this.DetailedMessage = detailedMessage;
        }

        public string ParameterName { get; }
        public string? ShortMessage { get; }
        public string? DetailedMessage { get; }
    }
}
