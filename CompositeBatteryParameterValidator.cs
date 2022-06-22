namespace BatteryManagementSystem
{
    using System;
    using System.Collections.Generic;

    public class CompositeBatteryParameterValidator : IBatteryParameterValidator
    {
        private readonly IList<IBatteryParameterValidator> _BatteryParameterValidators;

        public CompositeBatteryParameterValidator(IList<IBatteryParameterValidator> batteryParameterValidators)
        {
            _BatteryParameterValidators = batteryParameterValidators;
        }

        public void UpdateCurrentParameterValue(float parameterValue)
        {
            throw new NotImplementedException();
        }

        public ValidatorResult IsParameterValueValid()
        {
            ValidatorResult result = null;

            foreach (var batteryParameterValidator in _BatteryParameterValidators)
            {
                result = batteryParameterValidator.IsParameterValueValid();

                if (!result.IsBatteryOk)
                {
                    break;
                }
            }

            return result;
        }
    }
}
