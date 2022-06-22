namespace BatteryManagementSystem
{
    public class GermanLanguagePrinter : Printer
    {
        public GermanLanguagePrinter()
        {
            AddMessage(MessageType.MaximumChargeRateLimit, "Die Laderate liegt über der Höchstgrenze!");
            AddMessage(MessageType.MaximumChargeRateWarning, "Warnung: Annäherung an die maximale Laderate!");
            AddMessage(MessageType.MaximumSocLimit, "SOC liegt über der Höchstgrenze!");
            AddMessage(MessageType.MaximumSocWarning, "Warnung: Ladespitze nähert sich!");
            AddMessage(MessageType.MinimumSocLimit, "SOC liegt unter der Mindestgrenze!");
            AddMessage(MessageType.MinimumSocWarning, "Warnung: Naht Entladung!");
            AddMessage(MessageType.MaximumTemperatureLimit, "Die Temperatur liegt über der Höchstgrenze!");
            AddMessage(MessageType.MinimumTemperatureWarning, "Warnung: Annäherung an niedrige Temperatur!");
            AddMessage(MessageType.MaximumTemperatureWarning, "Warnung: Annäherung an hohe Temperatur!");
            AddMessage(MessageType.MinimumTemperatureLimit, "Die Temperatur liegt unter dem Mindestgrenzwert!");
        }
    }
}
