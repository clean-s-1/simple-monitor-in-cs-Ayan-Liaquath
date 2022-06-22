namespace BatteryManagementSystem
{
    public class BatteryManagementSystem : IBatteryManagementSystem
    {
        public ValidatorResult IsBatteryOk(IBatteryParameterValidator batteryParameterValidator)
        {
            return batteryParameterValidator.IsParameterValueValid();
        }
    }
}
