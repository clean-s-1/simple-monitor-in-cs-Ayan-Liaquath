public interface IChargeRateValidator
{
    bool CheckIfChargeRateIsValid(float maximumChargeRate, float currentChargeRate);
}
