namespace BatteryManagementSystem
{
    public interface IBatteryManagementSystem
    {
        ValidatorResult IsBatteryOk(IBatteryParameterValidator batteryParameterValidator);
    }
}
