using WordGuessing.App.Application;

namespace WordGuessing.Test.Application;

public class WordListTests
{
    [Fact]
    public void GetRandomWord_ReturnsRandomWord()
    {
        for (var i = 0; i < 100; i++)
        {
            var word = WordList.GetRandomWord();
            Assert.Contains(word, TestCommon.Words);
        }
    }
}