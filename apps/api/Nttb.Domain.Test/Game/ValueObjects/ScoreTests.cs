using Nttb.Domain.Game.ValueObjects;

namespace Nttb.Data.Test.Game.ValueObjects;

public class ScoreTests
{
    [Test]
    public void InitialScoreIsZeroZero()
    {
        var sut = new Score();
        Assert.Multiple(() =>
        {
            Assert.That(sut.Home, Is.EqualTo(0));
            Assert.That(sut.Away, Is.EqualTo(0));
        });
    }
    
    [Test]
    public void ParseScore()
    {
        var sut = Score.Parse("1-2");
        Assert.Multiple(() =>
        {
            Assert.That(sut.Home, Is.EqualTo(1));
            Assert.That(sut.Away, Is.EqualTo(2));
        });
    }
    
    [TestCaseSource(nameof(SourceDataValidParsableScores))]
    public Score ParseValidScores(string score)
    {
        return Score.Parse(score);
    }
    
    [TestCaseSource(nameof(SourceDataInvalidParsableScores))]
    public void ThrowsExceptionWhenScoreIsInvalid(string score)
    {
        Assert.Throws<FormatException>(() => Score.Parse(score));
    }

    static IEnumerable<TestCaseData> SourceDataValidParsableScores
    {
        get
        {
            yield return new TestCaseData("1-2").Returns(Score.Create(1, 2));
            yield return new TestCaseData("11-9").Returns(Score.Create(11, 9));
            yield return new TestCaseData("9-11").Returns(Score.Create(9, 11));
        }
    }

    static IEnumerable<string> SourceDataInvalidParsableScores
    {
        get
        {
            yield return "1";
            yield return "1,2";
            yield return "1.2-3";
            yield return "1,2-3";
            yield return "1-2-3";
            yield return "1 -2";
            yield return "1- 2";
            yield return "1 - 2";
            yield return "1 - 2 - 3";
            yield return "-1-2"; // Negative score
            yield return "1--2"; // Negative score away team
            yield return "1-2-";
        }
    }
}