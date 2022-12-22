using Nttb.Domain.Common.Models;

namespace Nttb.Domain.Game.ValueObjects;

/// <summary>
/// Contains the score of a game.
/// </summary>
public class Score : ValueObject
{
    public int Home { get; private set; }
    public int Away { get; private set; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Home;
        yield return Away;
    }

    public static Score Parse(string input)
    {
        // Regex parser for the score.
        var regex = Shared.RegularExpressions.ScoreRegex();
        var result = regex.Match(input);
        if (!result.Success)
        {
            throw new FormatException("Illegal score format")
            {
                Data = { { nameof(input), input } }
            };
        }

        var home = int.Parse(result.Groups["home"].Value);
        var away = int.Parse(result.Groups["away"].Value);

        return Create(home, away);
    }
    
    public static Score Create(int home, int away)
    {
        return new Score { Home = home, Away = away };
    }
}