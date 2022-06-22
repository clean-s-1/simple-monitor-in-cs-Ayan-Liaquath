namespace BatteryManagementSystem
{
    using System;
    using System.Collections.Generic;

    public abstract class Printer : IPrinter
    {
        private readonly IDictionary<MessageType, string> _Messages;

        protected Printer()
        {
            _Messages = new Dictionary<MessageType, string>();
        }

        public void PrintGivenMessageType(MessageType messageType)
        {
            Console.WriteLine(FetchMessage(messageType));
        }

        public void AddMessage(MessageType messageType, string messageText)
        {
            if (_Messages.ContainsKey(messageType))
            {
                _Messages[messageType] = messageText;
            }

            _Messages.Add(messageType, messageText);
        }

        public void RemoveMessageType(MessageType messageType)
        {
            _Messages.Remove(messageType);
        }

        public string FetchMessage(MessageType messageType)
        {
            if (_Messages.ContainsKey(messageType))
            {
                return _Messages[messageType];
            }

            return string.Empty;
        }
    }
}
