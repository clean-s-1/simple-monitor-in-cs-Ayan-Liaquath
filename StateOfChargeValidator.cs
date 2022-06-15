namespace BatteryManagementSystem
{
    using System;

    public class StateOfChargeValidator : IStateOfChargeValidator
    {
        public bool CheckIfStateOfChargeIsInGivenRange(float minimumSoc, float maximumSoc, float currentSoc)
        {
            if (currentSoc < minimumSoc || currentSoc > maximumSoc)
            {
                Console.WriteLine("State of Charge is out of range!");
                return false;
            }

            return true;
        }
    }
}
