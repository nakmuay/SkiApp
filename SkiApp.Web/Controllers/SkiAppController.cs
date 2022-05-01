namespace SkiApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkiApp.Services;
    using SkiApp.Services.Interfaces;

    [ApiController]
    public sealed class SkiAppController : ControllerBase
    {
        private readonly ILogger<SkiAppController> _logger;
        private readonly ISkiLengthService _skiLengthService;

        public SkiAppController(ILogger<SkiAppController> logger, ISkiLengthService skiLengthService)
        {
            this._logger = logger;
            this._skiLengthService = skiLengthService;
        }

        [HttpGet]
        [Route("api/computeskilength")]
        public ActionResult GetSkiLength(int age, int height, string skiType)
        {
            var responseBuilder = new GetSkiLengthResponse.Builder();
            GetSkiLengthResponse? response = null;

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

            var skiTypeOpt = SkiType.Classic;
            switch (skiType.ToUpperInvariant())
            {
                case "CLASSIC":
                    skiTypeOpt = SkiType.Classic;
                    break;

                case "FREESTYLE":
                    skiTypeOpt = SkiType.Freestyle;
                    break;
                default:
                    hasValidParameters = false;
                    responseBuilder
                        .WithParameterError(QueryParameters.SkiTypeParameterName)
                        .WithShortErrorMessage($"Invalid {QueryParameters.SkiTypeParameterName} parameter")
                        .WithDetailedErrorMessage($"Only {nameof(SkiType.Classic)} and {nameof(SkiType.Freestyle)} is supported for the {QueryParameters.SkiTypeParameterName} parameter, was: {skiType}.");
                    break;
            }

            if (!hasValidParameters)
            {
                response = responseBuilder;
                return Ok(response);
            }


            var result = this._skiLengthService.GetSkiLength(age, height, skiTypeOpt);
            result.Match(
                left =>
                {
                    //response = responseBuilder.WithShortErrorMessage(left);
                },
                right =>
                {
                    response = responseBuilder.WithSkiLength(right.Length);
                });

            return Ok(response);
        }
    }
}