using WordGuessing.App.Interfaces;

namespace WordGuessing.App.UI
{
    internal class ConsoleWriter : IMessageWriter
    {

        public void WriteLineMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLineSuccessMessage(string message)
        {
            var orgColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = orgColor;
        }

        public void WriteLineFailedMessage(string message)
        {
            var orgColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = orgColor;
        }

    }
}
