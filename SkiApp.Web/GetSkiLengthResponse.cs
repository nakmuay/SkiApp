namespace SkiApp.Web
{
    using SkiApp.Web.Errors;

    internal sealed class GetSkiLengthResponse
    {
        private GetSkiLengthResponse(int? skiLength, IEnumerable<ApiError>? errors)
        {
            this.SkiLength = skiLength;
            this.Errors = errors;
        }

        public int? SkiLength { get; }
        public IEnumerable<ApiError>? Errors { get; }

        internal class Builder
        {
            private List<ApiErrorBuilder> _nestedBuilders = new();
            private int? _skiLength;

            public Builder WithSkiLength(int skiLength)
            {
                this._skiLength = skiLength;
                return this;
            }

            public ApiInternalErrorBuilder WithInternalError()
            {
                var nestedBuilder = new ApiInternalErrorBuilder(this);
                this._nestedBuilders.Add(nestedBuilder);
                return nestedBuilder;
            }

            public ApiParameterValidationBuilder WithParameterError(string parameterName)
            {
                var nestedBuilder = new ApiParameterValidationBuilder(this, parameterName);
                this._nestedBuilders.Add(nestedBuilder);
                return nestedBuilder;
            }

            public static implicit operator GetSkiLengthResponse(Builder builder)
            {
                var errors = builder._nestedBuilders.Select(b => b.Build());
                return new GetSkiLengthResponse(builder._skiLength, errors.Any() ? errors : null);
            }

            internal abstract class ApiErrorBuilder
            {
                protected readonly Builder _owner;

                protected string? _shortMessage;

                protected string? _detailedMessage;

                internal ApiErrorBuilder(Builder owner)
                {
                    this._owner = owner;
                }

                public ApiErrorBuilder WithShortErrorMessage(string shortMessage)
                {
                    this._shortMessage = shortMessage;
                    return this;
                }

                public ApiErrorBuilder WithDetailedErrorMessage(string detailedMessage)
                {
                    this._detailedMessage = detailedMessage;
                    return this;
                }

                protected abstract ApiError BuildCore();

                public ApiError Build()
                {
                    return this.BuildCore();
                }
            }

            internal sealed class ApiInternalErrorBuilder : ApiErrorBuilder
            {
                public ApiInternalErrorBuilder(Builder owner) : base(owner)
                {
                }

                public ApiErrorBuilder WithInternalError()
                {
                    return this._owner.WithInternalError();
                }

                protected override ApiError BuildCore()
                {
                    return new ApiInternalError(this._shortMessage, this._detailedMessage);
                }
            }

            internal sealed class ApiParameterValidationBuilder : ApiErrorBuilder
            {
                private readonly string _parameterName;

                public ApiParameterValidationBuilder(Builder owner, string parameterName) : base(owner)
                {
                    this._parameterName = parameterName;
                }

                public ApiErrorBuilder WithParameterError(string parameterName)
                {
                    return this._owner.WithParameterError(parameterName);
                }

                protected override ApiError BuildCore()
                {
                    return new ApiParameterValidationError(this._parameterName, this._shortMessage, this._detailedMessage);
                }
            }
        }
    }
}
