namespace SkiiApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetSkiiLength(int age, int height)
        {
            var responseBuilder = new GetSkiiLengthResponse.Builder();
            GetSkiiLengthResponse? response = null;

            var hasValidParameters = true;
            if (age < 0)
            {
                hasValidParameters = false;

                responseBuilder.WithParameterError(QueryParameters.AgeParameterName)
                    .WithShortErrorMessage("Invalid age parameter.")
                    .WithDetailedErrorMessage($"A non-negative age is required, was  : {age}");
            }

            if (height < 0)
            {
                hasValidParameters = false;

                responseBuilder.WithParameterError(QueryParameters.HeightParameterName)
                    .WithShortErrorMessage("Invalid height parameter.")
                    .WithDetailedErrorMessage($"A non-negative height is required, was  : {height}");
            }

            if (!hasValidParameters)
            {
                response = responseBuilder;
                return Ok(response);
            }


            var result = this._skiiLengthService.GetSkiiLength(age, height);
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