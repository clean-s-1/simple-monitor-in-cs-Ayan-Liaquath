using System;

using BatteryManagementSystem;

public class Checker
{
    private static bool BatteryIsOk(float temperature, float soc, float chargeRate,
                                    IThermalControlValidator thermalControlValidator, IStateOfChargeValidator stateOfChargeValidator, IChargeRateValidator chargeRateValidator)
    {
        if (!thermalControlValidator.CheckIfBatteryTemperatureIsInGivenRange(0, 45, temperature))
        {
            return false;
        }

        if (!stateOfChargeValidator.CheckIfStateOfChargeIsInGivenRange(20, 80, soc))
        {
            return false;
        }

        if (!chargeRateValidator.CheckIfChargeRateIsValid(0.8f, chargeRate))
        {
            return false;
        }

        return true;
    }

    private static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
        }
    }

    private static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
        }
    }

    static int Main()
    {
        var thermalControlValidator = new ThermalControlValidator();
        var stateOfChargeValidator = new StateOfChargeValidator();
        var chargeRateValidator = new ChargeRateValidator();

        ExpectTrue(BatteryIsOk(25, 70, 0.7f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectTrue(BatteryIsOk(44, 79, 0.7f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectTrue(BatteryIsOk(0, 20, 0.7f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectFalse(BatteryIsOk(50, 85, 0.0f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectFalse(BatteryIsOk(40, 85, 0.0f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectFalse(BatteryIsOk(40, 79, 0.9f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectFalse(BatteryIsOk(-1, 79, 0.7f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        ExpectFalse(BatteryIsOk(20, 15, 0.7f, thermalControlValidator, stateOfChargeValidator, chargeRateValidator));
        return 0;
    }
}
