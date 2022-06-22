namespace BatteryManagementSystem
{
    public interface IBatteryParameterValidator
    {
        void UpdateCurrentParameterValue(float parameterValue);

        ValidatorResult IsParameterValueValid();
    }
}
