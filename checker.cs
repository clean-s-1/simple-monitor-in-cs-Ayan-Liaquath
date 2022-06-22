namespace BatteryManagementSystem
{
    using System;
    using System.Collections.Generic;

    public class Checker
    {
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
            var languagePrinter = new LanguageSpecificPrinter(Language.English);
            var chargeRateValidator = new ChargeRateValidator(0.8f, languagePrinter);
            var stateOfChargeValidator = new StateOfChargeValidator(20, 80, languagePrinter);
            var thermalControlValidator = new ThermalControlValidator(0, 45, languagePrinter);

            var compositeValidator = new CompositeBatteryParameterValidator(
                new List<IBatteryParameterValidator>
                    {
                        chargeRateValidator,
                        stateOfChargeValidator,
                        thermalControlValidator
                    });

            var batteryManagementSystem = new BatteryManagementSystem();

            chargeRateValidator.UpdateCurrentParameterValue(0.7f);
            stateOfChargeValidator.UpdateCurrentParameterValue(70);
            thermalControlValidator.UpdateCurrentParameterValue(25);

            ExpectTrue(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            stateOfChargeValidator.UpdateCurrentParameterValue(79);
            thermalControlValidator.UpdateCurrentParameterValue(44);

            ExpectTrue(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            stateOfChargeValidator.UpdateCurrentParameterValue(20);
            thermalControlValidator.UpdateCurrentParameterValue(0);

            ExpectTrue(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);
            
            chargeRateValidator.UpdateCurrentParameterValue(0.0f);
            stateOfChargeValidator.UpdateCurrentParameterValue(85);
            thermalControlValidator.UpdateCurrentParameterValue(50);

            ExpectFalse(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            thermalControlValidator.UpdateCurrentParameterValue(40);

            ExpectFalse(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            chargeRateValidator.UpdateCurrentParameterValue(0.9f);
            stateOfChargeValidator.UpdateCurrentParameterValue(79);

            ExpectFalse(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            chargeRateValidator.UpdateCurrentParameterValue(0.7f);
            thermalControlValidator.UpdateCurrentParameterValue(-1);

            ExpectFalse(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            thermalControlValidator.UpdateCurrentParameterValue(20);
            stateOfChargeValidator.UpdateCurrentParameterValue(15);

            ExpectFalse(batteryManagementSystem.IsBatteryOk(compositeValidator).IsBatteryOk);

            return 0;
        }
    }
}
