namespace BatteryManagementSystem
{
    public class ValidatorResult
    {
        public ValidatorResult(
            bool isBatteryOk,
            string errorInformation)
        {
            IsBatteryOk = isBatteryOk;
            ErrorInformation = errorInformation;
        }

        public bool IsBatteryOk { get; }

        public string ErrorInformation { get; }
    }
}
