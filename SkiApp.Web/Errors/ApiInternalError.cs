namespace SkiApp.Web.Errors
{
    internal sealed class ApiInternalError : ApiError
    {
        public ApiInternalError(string? shortMessage, string? detailedMessage) : base(shortMessage, detailedMessage)
        {
        }
    }
}
