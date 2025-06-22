using System.Runtime.CompilerServices;
using WordGuessing.App.Interfaces;

namespace WordGuessing.Test.Stubs
{
    internal class TestInputReader : IInputReader
    {
        //連続実行のテスト時、外部から指定した入力値を順番に返すためのキュー
        private readonly Queue<Queue<char>> _testWordQueues = new Queue<Queue<char>>();
        private Queue<char> _currentQueue;
        private int _continueCount;

        public TestInputReader(string[] testWords, int continueCount)
        {
            foreach (var testWord in testWords)
            {
                _testWordQueues.Enqueue(new Queue<char>(testWord.ToCharArray()));
            }
            _continueCount = continueCount;
        }

        public char Read(string message)
        {
            if (message == "アルファベットを入力してください。")
            {
                if (_currentQueue == null)
                {
                    _currentQueue = _testWordQueues.Dequeue();
                }
                return _currentQueue.Dequeue();
            }
            if (message == "続けますか？(y/n)")
            {
                _testWordQueues.TryDequeue(out _currentQueue);
                if (_continueCount > 0)
                {
                    _continueCount--;
                    return 'y';
                }
                else
                {
                    return 'n';
                }
            }
            else
            {
                return 'a';
            }
        }
    }
}
