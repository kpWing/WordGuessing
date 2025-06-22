using WordGuessing.App.Application;
using WordGuessing.App.Models;

namespace WordGuessing.Test.Models;

public class TargetWordTests
{
    [Fact]
    public void GetRevealedWord_InputCorrectChar_ReturnsRevealedString()
    {
        var sut = new TargetWord("test");

        var ret1 = sut.GetRevealedWord('t');
        var ret2 = sut.GetRevealedWord('e');
        var ret3 = sut.GetRevealedWord('s');

        Assert.Equal("t__t", ret1);
        Assert.Equal("te_t", ret2);
        Assert.Equal("test", ret3);
    }

    [Fact]
    public void GetRevealedWord_InputInvalidChar_ReturnsNotRevealedString()
    {
        var sut = new TargetWord("test");

        var ret = sut.GetRevealedWord('a');

        Assert.Equal("____", ret);
    }
}