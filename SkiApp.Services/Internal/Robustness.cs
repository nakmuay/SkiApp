namespace SkiApp.Services.Internal
{
    internal static class Robustness
    {
        public static void ValidateArgumentWithinRange(
            string argName,
            int value,
            int minValue,
            int maxValue
            )
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException($"Argument '{argName}' should be within range [{minValue}, {maxValue}] but was {value}");
            }
        }

        public static void ValidateArgumentNonNegative(string argName, int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"Argument {argName} should be non-negative but was {value}.");
            }
        }
    }
}
