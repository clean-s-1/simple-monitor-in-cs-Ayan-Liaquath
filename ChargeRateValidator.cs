namespace BatteryManagementSystem
{
    public class ChargeRateValidator : IBatteryParameterValidator
    {
        private readonly IPrinter _Printer;

        private readonly float _MaximumChargeRate;

        private readonly bool _IsWarningNeeded;

        private readonly float _WarningPercentage;

        private float _CurrentChargeRate;

        public ChargeRateValidator(
            float maximumChargeRate,
            IPrinter printer,
            bool isWarningNeeded = true,
            float warningPercentage = 5)
        {
            _MaximumChargeRate = maximumChargeRate;
            _Printer = printer;
            _IsWarningNeeded = isWarningNeeded;
            _WarningPercentage = warningPercentage;
        }

        public void UpdateCurrentParameterValue(float parameterValue)
        {
            _CurrentChargeRate = parameterValue;
        }

        public ValidatorResult IsParameterValueValid()
        {
            if (_CurrentChargeRate > _MaximumChargeRate)
            {
                _Printer.PrintGivenMessageType(MessageType.MaximumChargeRateLimit);

                return new ValidatorResult(false, _Printer.FetchMessage(MessageType.MaximumChargeRateLimit));
            }

            CheckForWarnings();

            return new ValidatorResult(true, string.Empty);
        }

        private void CheckForWarnings()
        {
            if (_IsWarningNeeded)
            {
                CheckForMaximumLimitWarning();
            }
        }

        private void CheckForMaximumLimitWarning()
        {
            if (_CurrentChargeRate
                >= WarningValueCalculator.CalculateMaximumWarningLimit(_WarningPercentage, _MaximumChargeRate))
            {
                _Printer.PrintGivenMessageType(MessageType.MaximumChargeRateWarning);
            }
        }
    }
}
