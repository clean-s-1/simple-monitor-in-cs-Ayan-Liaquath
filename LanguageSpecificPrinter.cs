namespace BatteryManagementSystem
{
    using System.Collections.Generic;

    public class LanguageSpecificPrinter : IPrinter
    {
        private readonly IDictionary<Language, IPrinter> _Printers;

        private readonly Language _Language;

        public LanguageSpecificPrinter(Language language)
        {
            _Printers = new Dictionary<Language, IPrinter>
            {
                { Language.English, new EnglishLanguagePrinter() },
                { Language.German, new GermanLanguagePrinter() }
            };

            _Language = language;
        }

        public void PrintGivenMessageType(MessageType messageType)
        {
            if (_Printers.ContainsKey(_Language))
            {
                _Printers[_Language].PrintGivenMessageType(messageType);
            }
        }

        public void AddMessage(MessageType messageType, string messageText)
        {
            if (_Printers.ContainsKey(_Language))
            {
                _Printers[_Language].AddMessage(messageType, messageText);
            }
        }

        public void RemoveMessageType(MessageType messageType)
        {
            if (_Printers.ContainsKey(_Language))
            {
                _Printers[_Language].RemoveMessageType(messageType);
            }
        }

        public string FetchMessage(MessageType messageType)
        {
            if (_Printers.ContainsKey(_Language))
            {
                return _Printers[_Language].FetchMessage(messageType);
            }

            return string.Empty;
        }
    }
}
