namespace WordGuessing.App.Interfaces
{
    internal class ConsoleReader : IInputReader
    {
        public char Read(string message)
        {
            Console.WriteLine(message);
            var c = Console.ReadKey(intercept: true).KeyChar;
            Console.WriteLine($"入力値:{c}");
            return c;
        }
    }
}
