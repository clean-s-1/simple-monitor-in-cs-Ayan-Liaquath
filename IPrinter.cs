namespace BatteryManagementSystem
{
    public interface IPrinter
    {
        void PrintGivenMessageType(MessageType messageType);

        void AddMessage(MessageType messageType, string messageText);

        void RemoveMessageType(MessageType messageType);

        string FetchMessage(MessageType messageType);
    }
}
