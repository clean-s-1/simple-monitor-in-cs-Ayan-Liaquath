public interface IThermalControlValidator
{
    bool CheckIfBatteryTemperatureIsInGivenRange(
        float minimumTemperature,
        float maximumTemperature,
        float currentTemperature);
}
