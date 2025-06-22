using System.Text.RegularExpressions;
using WordGuessing.App.Interfaces;
using WordGuessing.App.Models;

namespace WordGuessing.App.Application
{
    internal class GameProcessor
    {
        //ユーザインタラクションに関する機能はコンソール以外のインターフェースへの差し替えを考慮して、外部から注入
        private readonly IMessageWriter _messageWriter;
        private readonly IInputReader _reader;

        private readonly WordCreator _wordCreator = new WordCreator();

        public int MaxFailableCount { get; }
        public GameProcessor(int failableCount
            , IMessageWriter messageWriter
            , IInputReader reader)
        {
            MaxFailableCount = failableCount;
            _messageWriter = messageWriter;
            _reader = reader;
        }

        public void StartGame()
        {
            var count = 0;
            var isContinue = true;
            while (isContinue)
            {
                count++;
                _messageWriter.WriteLineMessage($"問題{count}============================");
                var word = _wordCreator.Create(WordList.GetRandomWord());

                ExecuteQuestion(word);
                isContinue = IsContinue();
            }

            _messageWriter.WriteLineMessage("ゲームを終了します。");
        }

        private void ExecuteQuestion(TargetWord word)
        {
            var currentOutputWord = word.MaskedValue;
            var inputedKeys = new HashSet<char>();
            var currentFailableCount = MaxFailableCount;
            while (true)
            {
                WriteQuestion(currentOutputWord, currentFailableCount, inputedKeys);

                var charValue = ReadKey();
                inputedKeys.Add(charValue);

                var revealedWord = word.GetRevealedWord(charValue);
                if (revealedWord == currentOutputWord)
                {
                    currentFailableCount--;
                }
                else
                {
                    currentOutputWord = revealedWord;
                }

                if (revealedWord == word.Value)
                {
                    _messageWriter.WriteLineMessage(word.Value);
                    _messageWriter.WriteLineSuccessMessage("おめでとうございます!正解です。");
                    _messageWriter.WriteLineMessage("");

                    break;
                }
                else if (currentFailableCount == 0)
                {
                    _messageWriter.WriteLineFailedMessage("ゲームオーバーです。");
                    _messageWriter.WriteLineFailedMessage($"正解: {word.Value}");
                    _messageWriter.WriteLineMessage("");

                    break;
                }
            }
        }

        private void WriteQuestion(string value, int currentFailableCount, IEnumerable<char> inputedKeys)
        {
            _messageWriter.WriteLineMessage(value);
            _messageWriter.WriteLineMessage(currentFailableCount.ToString());
            _messageWriter.WriteLineMessage($"入力済みの文字:[{string.Join(',', inputedKeys)}]");
            _messageWriter.WriteLineMessage("");
        }

        private char ReadKey()
        {
            while (true)
            {
                var charValue = _reader.Read("アルファベットを入力してください。");
                if (IsAlphabet(charValue))
                {
                    return charValue;
                }
            }
        }

        private bool IsAlphabet(char c)
        {
            var alphabetRegex = new Regex(@"^[a-zA-Z]$");
            return alphabetRegex.IsMatch(c.ToString());
        }

        private bool IsContinue()
        {
            var answer = _reader.Read("続けますか？(y/n)");
            if (char.ToUpper(answer) == 'Y')
            {
                return true;
            }
            else if (char.ToUpper(answer) == 'N')
            {
                return false;
            }
            else
            {
                return IsContinue();
            }
        }
    }
}
