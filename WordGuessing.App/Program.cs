using System.Text.RegularExpressions;
using WordGuessing.App;
using WordGuessing.App.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var creator = new WordCreator();
        IInputReader reader = new ConsoleReader();

        var count = 0;
        while(true)
        {
            var failableCount = 5;
            count++;
            Console.WriteLine($"問題{count}============================");
            var word = creator.Create(WordList.GetRandomWord());

            var currentOutputWord = word.MaskedValue;
            while (true)
            {
                WriteProblem(currentOutputWord, failableCount);

                char charValue;
                while (true)
                {
                    charValue = reader.Read("アルファベットを入力してください。");
                    if (IsAlphabet(charValue))
                    {
                        break;
                    }
                }


                var revealedWord = word.GetRevealedWord(charValue);
                if(revealedWord == currentOutputWord)
                {
                    failableCount--;
                }else
                {
                    currentOutputWord = revealedWord;
                }

                if(revealedWord == word.Value)
                {
                    Console.WriteLine(word.Value);

                    var orgColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("おめでとうございます。正解です。");
                    Console.ForegroundColor = orgColor;

                    break;
                }else if (failableCount == 0)
                {
                    var orgColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ゲームオーバーです。");
                    Console.WriteLine($"正解: {word.Value}");
                    Console.ForegroundColor = orgColor;

                    break;
                }
            }

        }
    }

    private static void WriteProblem(string value, int failableCount)
    {
        Console.WriteLine($"単語: {value}");
        Console.WriteLine($"残り失敗可能回数: {failableCount}");
    }

    private static bool IsAlphabet(char c)
    {
        var alphabetRegex = new Regex(@"^[a-zA-Z]$");
        return alphabetRegex.IsMatch(c.ToString());
    }
}