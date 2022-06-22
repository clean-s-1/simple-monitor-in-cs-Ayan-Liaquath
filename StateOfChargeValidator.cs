namespace BatteryManagementSystem
{
    public class StateOfChargeValidator : IBatteryParameterValidator
    {
        private readonly IPrinter _Printer;

        private float _MinimumSoc;

        private float _MaximumSoc;

        private readonly bool _IsWarningNeeded;

        private readonly float _WarningPercentage;

        private float _CurrentSoc;

        public StateOfChargeValidator(
            float minimumSoc,
            float maximumSoc,
            IPrinter printer,
            bool isWarningNeeded = true,
            float warningPercentage = 5)
        {
            _MaximumSoc = maximumSoc;
            _MinimumSoc = minimumSoc;
            _Printer = printer;
            _IsWarningNeeded = isWarningNeeded;
            _WarningPercentage = warningPercentage;
        }

        public void UpdateCurrentParameterValue(float parameterValue)
        {
            _CurrentSoc = parameterValue;
        }

        public ValidatorResult IsParameterValueValid()
        {
            if (_CurrentSoc < _MinimumSoc)
            {
                _Printer.PrintGivenMessageType(MessageType.MinimumSocLimit);
                return new ValidatorResult(false, _Printer.FetchMessage(MessageType.MinimumSocLimit));
            }

            if (_CurrentSoc > _MaximumSoc)
            {
                _Printer.PrintGivenMessageType(MessageType.MaximumSocLimit);
                return new ValidatorResult(false, _Printer.FetchMessage(MessageType.MaximumSocLimit));
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
            if (_CurrentSoc
                >= WarningValueCalculator.CalculateMaximumWarningLimit(_WarningPercentage, _MaximumSoc))
            {
                _Printer.PrintGivenMessageType(MessageType.MaximumSocWarning);
            }
        }

        private void CheckForMinimumLimitWarning()
        {
            if (_CurrentSoc
                <= WarningValueCalculator.CalculateMinimumWarningLimit(_WarningPercentage, _MinimumSoc))
            {
                _Printer.PrintGivenMessageType(MessageType.MinimumSocWarning);
            }
        }
    }
}
