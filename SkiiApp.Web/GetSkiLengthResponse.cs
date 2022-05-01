namespace SkiiApp.Web
{
    using SkiiApp.Web.Errors;

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

            public ApiErrorBuilder WithParameterError(string parameterName)
            {
                var nestedBuilder = new ApiErrorBuilder(this, parameterName);
                this._nestedBuilders.Add(nestedBuilder);
                return nestedBuilder;
            }

            public static implicit operator GetSkiLengthResponse(Builder builder)
            {
                var errors = builder._nestedBuilders.Select(b => b.Build());
                return new GetSkiLengthResponse(builder._skiLength, errors.Any() ? errors : null);
            }

            internal sealed class ApiErrorBuilder {
                private readonly Builder _owner;
                
                private readonly string _parameterName;

                private string? _shortMessage;

                private string? _detailedMessage;

                internal ApiErrorBuilder(Builder owner, string parameterName)
                {
                    this._owner = owner;
                    this._parameterName = parameterName;
                }

                public ApiErrorBuilder WithParameterError(string parameterName)
                {
                    return this._owner.WithParameterError(parameterName);
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

                public ApiError Build()
                {
                    return new ApiError(this._parameterName, this._shortMessage, this._detailedMessage);
                }

            }
        }
    }
}
