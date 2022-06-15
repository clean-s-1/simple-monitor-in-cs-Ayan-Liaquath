namespace BatteryManagementSystem
{
    public interface IStateOfChargeValidator
    {
        bool CheckIfStateOfChargeIsInGivenRange(
            float minimumSoc,
            float maximumSoc,
            float currentSoc);
    }
}
