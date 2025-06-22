using WordGuessing.App;
using WordGuessing.App.Application;
using WordGuessing.App.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        var processor = new GameProcessor(
            5
            , new ConsoleWriter()
            , new ConsoleReader()
            , new WordCreator());
        processor.StartGame();

        Console.ReadKey();
    }
}