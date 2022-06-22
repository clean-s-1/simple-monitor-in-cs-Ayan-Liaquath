namespace BatteryManagementSystem
{
    public static class WarningValueCalculator
    {
        public static float CalculateMaximumWarningLimit(float warningPercentage, float maximumLimit)
        {
            return maximumLimit - CalculateToleranceValue(warningPercentage, maximumLimit);
        }

        public static float CalculateMinimumWarningLimit(float warningPercentage, float minimumLimit)
        {
            return minimumLimit + CalculateToleranceValue(warningPercentage, minimumLimit);
        }

        private static float CalculateToleranceValue(float warningPercentage, float limit)
        {
            return (warningPercentage * limit) / 100;
        }
    }
}
