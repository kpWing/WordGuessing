using System.Text;
using WordGuessing.App.Interfaces;

namespace WordGuessing.Test.Stubs
{
    internal class TestMessageWriter : IMessageWriter
    {
        public StringBuilder Message { get; set; } = new StringBuilder();
        public StringBuilder FailedMessage { get; set; } = new StringBuilder();
        public StringBuilder SuccessMessage { get; set; } = new StringBuilder();


        public void WriteLineFailedMessage(string message)
        {
            FailedMessage.AppendLine(message);
        }

        public void WriteLineMessage(string message)
        {
            Message.AppendLine(message);
        }

        public void WriteLineSuccessMessage(string message)
        {
            SuccessMessage.AppendLine(message);
        }
    }
}
