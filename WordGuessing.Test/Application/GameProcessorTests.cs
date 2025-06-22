using WordGuessing.App.Application;
using WordGuessing.App.Interfaces;
using WordGuessing.Test.Stubs;

namespace WordGuessing.Test.Application;

public class GameProcessorTests
{
    /// <summary>
    /// �ő�񐔈ȓ��ɐ������ăQ�[�����I���
    /// </summary>
    [Fact]
    public void StartGame_Sucess_ReturnsSuccessMessage()
    {
        var testMessageWriter = new TestMessageWriter();
        var sut = new GameProcessor(
            2
            , testMessageWriter
            , new TestInputReader(new string[1] { "test" }, 0)
            , new TestWordCreator(new string[1] { "Test" })
            );

        sut.StartGame();

        var msg = testMessageWriter.Message.ToString();
        var sucessMsg = testMessageWriter.SuccessMessage.ToString();
        var failedMsg = testMessageWriter.FailedMessage.ToString();

        Assert.Equal(@"���1============================
____
2
���͍ς݂̕���:[]

T__t
2
���͍ς݂̕���:[t]

Te_t
2
���͍ς݂̕���:[t,e]

Test

�Q�[�����I�����܂��B
", msg);

        Assert.Equal(@"���߂łƂ��������܂�!�����ł��B
", sucessMsg);
        Assert.Empty(failedMsg);
    }

    /// <summary>
    /// //�ő�񐔂܂Ŏ��s���ăQ�[�����I���
    /// </summary>
    [Fact]
    public void StartGame_Fail_ReturnsFailedMessage()
    {
        var testMessageWriter = new TestMessageWriter();
        var sut = new GameProcessor(
            2
            , testMessageWriter
            , new TestInputReader(new string[1] { "tab" }, 0)
            , new TestWordCreator(new string[1] { "Test" })
            );

        sut.StartGame();

        var msg = testMessageWriter.Message.ToString();
        var sucessMsg = testMessageWriter.SuccessMessage.ToString();
        var failedMsg = testMessageWriter.FailedMessage.ToString();

        Assert.Equal(@"���1============================
____
2
���͍ς݂̕���:[]

T__t
2
���͍ς݂̕���:[t]

T__t
1
���͍ς݂̕���:[t,a]

T__t
0
���͍ς݂̕���:[t,a,b]


�Q�[�����I�����܂��B
", msg);

        Assert.Empty(sucessMsg);
        Assert.Equal(@"�Q�[���I�[�o�[�ł��B
����: Test
", failedMsg);
    }

    /// <summary>
    /// �Q�[����A�����Ď��s�ł���
    /// </summary>
    [Fact]
    public void StartGame_Continue_CanPlayContinuously()
    {
        var testMessageWriter = new TestMessageWriter();
        var sut = new GameProcessor(
            2
            , testMessageWriter
            , new TestInputReader(new string[2] { "test", "pdb" }, 1)
            , new TestWordCreator(new string[2] { "Test", "happy" })
            );

        sut.StartGame();

        var msg = testMessageWriter.Message.ToString();
        var sucessMsg = testMessageWriter.SuccessMessage.ToString();
        var failedMsg = testMessageWriter.FailedMessage.ToString();

        Assert.Equal(@"���1============================
____
2
���͍ς݂̕���:[]

T__t
2
���͍ς݂̕���:[t]

Te_t
2
���͍ς݂̕���:[t,e]

Test

���2============================
_____
2
���͍ς݂̕���:[]

__pp_
2
���͍ς݂̕���:[p]

__pp_
1
���͍ς݂̕���:[p,d]

__pp_
0
���͍ς݂̕���:[p,d,b]


�Q�[�����I�����܂��B
", msg);

        Assert.Equal(@"���߂łƂ��������܂�!�����ł��B
", sucessMsg);
        Assert.Equal(@"�Q�[���I�[�o�[�ł��B
����: happy
", failedMsg);
    }
}