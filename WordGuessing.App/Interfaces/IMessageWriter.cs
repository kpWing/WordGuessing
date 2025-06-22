namespace WordGuessing.App.Interfaces
{
    public interface IMessageWriter
    {
        void WriteLineMessage(string message);
        void WriteLineSuccessMessage(string message);
        void WriteLineFailedMessage(string message);
    }
}
