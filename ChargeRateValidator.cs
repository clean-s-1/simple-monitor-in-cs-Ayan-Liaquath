namespace BatteryManagementSystem
{
    using System;

    public class ChargeRateValidator : IChargeRateValidator
    {
        public bool CheckIfChargeRateIsValid(float maximumChargeRate, float currentChargeRate)
        {
            if (currentChargeRate > maximumChargeRate)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }

            return true;
        }
    }
}
