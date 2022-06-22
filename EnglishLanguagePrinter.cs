namespace BatteryManagementSystem
{
    public class EnglishLanguagePrinter : Printer
    {
        public EnglishLanguagePrinter()
        {
            AddMessage(MessageType.MaximumChargeRateLimit, "Charge Rate is above maximum limit!");
            AddMessage(MessageType.MaximumChargeRateWarning, "Warning: Approaching maximum Charge rate!");
            AddMessage(MessageType.MaximumSocLimit, "SOC is above maximum limit!");
            AddMessage(MessageType.MaximumSocWarning, "Warning: Approaching charge-peak!");
            AddMessage(MessageType.MinimumSocLimit, "SOC is below minimum limit!");
            AddMessage(MessageType.MinimumSocWarning, "Warning: Approaching discharge!");
            AddMessage(MessageType.MaximumTemperatureLimit, "Temperature is above maximum limit!");
            AddMessage(MessageType.MinimumTemperatureWarning, "Warning: Approaching low temperature!");
            AddMessage(MessageType.MaximumTemperatureWarning, "Warning: Approaching high temperature!");
            AddMessage(MessageType.MinimumTemperatureLimit, "Temperature is below minimum limit!");
        }
    }
}
