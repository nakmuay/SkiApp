namespace SkiApp.Web.Errors
{
    internal sealed class ApiParameterValidationError : ApiError
    {
        public ApiParameterValidationError(string parameterName, string? shortMessage, string? detailedMessage)
            : base($"Invalid {parameterName} parameter", detailedMessage)
        {
            this.ParameterName = parameterName;
        }

        public string ParameterName { get; }
    }
}
