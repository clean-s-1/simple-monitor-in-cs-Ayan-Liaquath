namespace BatteryManagementSystem
{
    public class ThermalControlValidator : IBatteryParameterValidator
    {
        private readonly IPrinter _Printer;

        private float _MinimumTemperature;

        private float _MaximumTemperature;

        private readonly bool _IsWarningNeeded;

        private readonly float _WarningPercentage;

        private float _CurrentTemperature;

        public ThermalControlValidator(
            float minimumTemperature,
            float maximumTemperature,
            IPrinter printer,
            bool isWarningNeeded = true,
            float warningPercentage = 5)
        {
            _MinimumTemperature = minimumTemperature;
            _MaximumTemperature = maximumTemperature;
            _Printer = printer;
            _IsWarningNeeded = isWarningNeeded;
            _WarningPercentage = warningPercentage;
        }

        public void UpdateCurrentParameterValue(float parameterValue)
        {
            _CurrentTemperature = parameterValue;
        }

        public ValidatorResult IsParameterValueValid()
        {
            if (_CurrentTemperature < _MinimumTemperature)
            {
                _Printer.PrintGivenMessageType(MessageType.MinimumTemperatureLimit);
                return new ValidatorResult(false, _Printer.FetchMessage(MessageType.MinimumTemperatureLimit));
            }

            if (_CurrentTemperature > _MaximumTemperature)
            {
                _Printer.PrintGivenMessageType(MessageType.MaximumTemperatureLimit);
                return new ValidatorResult(false, _Printer.FetchMessage(MessageType.MaximumTemperatureLimit));
            }

            CheckForWarnings();

            return new ValidatorResult(true, string.Empty);
        }

        private void CheckForWarnings()
        {
            if (_IsWarningNeeded)
            {
                CheckForMaximumLimitWarning();
                CheckForMinimumLimitWarning();
            }
        }

        private void CheckForMaximumLimitWarning()
        {
            if (_CurrentTemperature
                >= WarningValueCalculator.CalculateMaximumWarningLimit(_WarningPercentage, _MaximumTemperature))
            {
                _Printer.PrintGivenMessageType(MessageType.MaximumTemperatureWarning);
            }
        }

        private void CheckForMinimumLimitWarning()
        {
            if (_CurrentTemperature
                <= WarningValueCalculator.CalculateMinimumWarningLimit(_WarningPercentage, _MinimumTemperature))
            {
                _Printer.PrintGivenMessageType(MessageType.MinimumTemperatureWarning);
            }
        }
    }
}
