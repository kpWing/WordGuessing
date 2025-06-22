using WordGuessing.App.Application;

namespace WordGuessing.Test.Application;

public class WordCreatorTests
{
    [Theory]
    [InlineData("TestWord", "________")]
    [InlineData("apple", "_____")]
    [InlineData("hobby", "_____")]
    [InlineData("birthday", "________")]
    [InlineData("international", "_____________")]
    public void Create_ReturnsCorrectProperty(string word, string expectedMaskedValue)
    {
        var sut = new WordCreator();
        var targetWord = sut.Create(word);

        Assert.Equal(word, targetWord.Value);
        Assert.Equal(expectedMaskedValue, targetWord.MaskedValue);
    }
}