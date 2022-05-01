namespace SkiiApp.Web
{
    using SkiiApp.Web.Errors;

    internal sealed class GetSkiiLengthResponse
    {
        private GetSkiiLengthResponse(int? skiiLength, IEnumerable<ApiError>? errors)
        {
            this.SkiiLength = skiiLength;
            this.Errors = errors;
        }

        public int? SkiiLength { get; }
        public IEnumerable<ApiError>? Errors { get; }

        internal class Builder
        {
            private List<ApiErrorBuilder> _nestedBuilders = new();
            private int? _skiiLength;

            public Builder WithSkiiLength(int skiiLength)
            {
                this._skiiLength = skiiLength;
                return this;
            }

            public ApiErrorBuilder WithParameterError(string parameterName)
            {
                var nestedBuilder = new ApiErrorBuilder(this, parameterName);
                this._nestedBuilders.Add(nestedBuilder);
                return nestedBuilder;
            }

            public static implicit operator GetSkiiLengthResponse(Builder builder)
            {
                var errors = builder._nestedBuilders.Select(b => b.Build());
                return new GetSkiiLengthResponse(builder._skiiLength, errors.Any() ? errors : null);
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
