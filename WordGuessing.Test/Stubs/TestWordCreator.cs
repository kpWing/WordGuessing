using WordGuessing.App.Interfaces;
using WordGuessing.App.Models;

namespace WordGuessing.Test.Stubs
{
    /// <summary>
    /// 政界の単語を外部から指定できるテスト用クラス
    /// </summary>
    internal class TestWordCreator : IWordCreator
    {
        //連続実行のテスト時、外部から指定した単語を順番に返すためのキュー
        private readonly Queue<string> _testWordQueue;
        public TestWordCreator(string[] testWords)
        {
            _testWordQueue = new Queue<string>(testWords);
        }

        public TargetWord Create(string value)
        {
            return new TargetWord(_testWordQueue.Dequeue());
        }
    }
}
