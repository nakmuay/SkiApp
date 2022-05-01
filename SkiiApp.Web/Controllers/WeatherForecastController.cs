namespace SkiiApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkiiApp.Services;
    using SkiiApp.Services.Interfaces;

    [ApiController]
    public sealed class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISkiiLengthService _skiiLengthService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISkiiLengthService skiiLengthService)
        {
            this._logger = logger;
            this._skiiLengthService = skiiLengthService;
        }

        [HttpGet]
        [Route("api/computeskiilength")]
        public ActionResult GetSkiiLength(int age, int height, string skiiType)
        {
            var responseBuilder = new GetSkiiLengthResponse.Builder();
            GetSkiiLengthResponse? response = null;

            var hasValidParameters = true;
            if (age < 0)
            {
                hasValidParameters = false;

                responseBuilder.WithParameterError(QueryParameters.AgeParameterName)
                    .WithShortErrorMessage($"Invalid {QueryParameters.AgeParameterName} parameter.")
                    .WithDetailedErrorMessage($"A non-negative {QueryParameters.AgeParameterName} is required, was: {age}.");
            }

            if (height < 0)
            {
                hasValidParameters = false;

                responseBuilder.WithParameterError(QueryParameters.HeightParameterName)
                    .WithShortErrorMessage($"Invalid {QueryParameters.HeightParameterName} parameter.")
                    .WithDetailedErrorMessage($"A non-negative {QueryParameters.HeightParameterName} is required, was: {height}.");
            }

            var skiiTypeOpt = SkiiType.Classic;
            switch (skiiType.ToUpperInvariant())
            {
                case "CLASSSIC":
                    skiiTypeOpt = SkiiType.Classic;
                    break;

                case "FREESTYLE":
                    skiiTypeOpt = SkiiType.Freestyle;
                    break;
                default:
                    hasValidParameters = false;
                    responseBuilder
                        .WithParameterError(QueryParameters.SkiiTypeParameterName)
                        .WithShortErrorMessage($"Invalid {QueryParameters.SkiiTypeParameterName} parameter")
                        .WithDetailedErrorMessage($"Only {nameof(SkiiType.Classic)} and {nameof(SkiiType.Freestyle)} is supported for the {QueryParameters.SkiiTypeParameterName} parameter, was: {skiiType}.");
                    break;
            }

            if (!hasValidParameters)
            {
                response = responseBuilder;
                return Ok(response);
            }


            var result = this._skiiLengthService.GetSkiiLength(age, height, skiiTypeOpt);
            result.Match(
                left =>
                {
                    //response = responseBuilder.WithShortErrorMessage(left);
                },
                right =>
                {
                    response = responseBuilder.WithSkiiLength(right.Length);
                });

            return Ok(response);
        }
    }
}