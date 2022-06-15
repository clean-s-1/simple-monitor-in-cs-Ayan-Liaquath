using System;

public class ThermalControlValidator : IThermalControlValidator
{
    public bool CheckIfBatteryTemperatureIsInGivenRange(
        float minimumTemperature,
        float maximumTemperature,
        float currentTemperature)
    {
        if (currentTemperature < minimumTemperature || currentTemperature > maximumTemperature)
        {
            Console.WriteLine("Temperature is out of range!");
            return false;
        }

        return true;
    }
}
