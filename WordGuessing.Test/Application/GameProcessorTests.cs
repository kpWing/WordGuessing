using WordGuessing.App.Application;
using WordGuessing.App.Interfaces;
using WordGuessing.Test.Stubs;

namespace WordGuessing.Test.Application;

public class GameProcessorTests
{
    /// <summary>
    /// 最大回数以内に成功してゲームが終わる
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

        Assert.Equal(@"問題1============================
____
2
入力済みの文字:[]

T__t
2
入力済みの文字:[t]

Te_t
2
入力済みの文字:[t,e]

Test

ゲームを終了します。
", msg);

        Assert.Equal(@"おめでとうございます!正解です。
", sucessMsg);
        Assert.Empty(failedMsg);
    }

    /// <summary>
    /// //最大回数まで失敗してゲームが終わる
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

        Assert.Equal(@"問題1============================
____
2
入力済みの文字:[]

T__t
2
入力済みの文字:[t]

T__t
1
入力済みの文字:[t,a]

T__t
0
入力済みの文字:[t,a,b]


ゲームを終了します。
", msg);

        Assert.Empty(sucessMsg);
        Assert.Equal(@"ゲームオーバーです。
正解: Test
", failedMsg);
    }

    /// <summary>
    /// ゲームを連続して実行できる
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

        Assert.Equal(@"問題1============================
____
2
入力済みの文字:[]

T__t
2
入力済みの文字:[t]

Te_t
2
入力済みの文字:[t,e]

Test

問題2============================
_____
2
入力済みの文字:[]

__pp_
2
入力済みの文字:[p]

__pp_
1
入力済みの文字:[p,d]

__pp_
0
入力済みの文字:[p,d,b]


ゲームを終了します。
", msg);

        Assert.Equal(@"おめでとうございます!正解です。
", sucessMsg);
        Assert.Equal(@"ゲームオーバーです。
正解: happy
", failedMsg);
    }
}