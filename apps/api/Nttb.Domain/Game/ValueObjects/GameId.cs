using Nttb.Domain.Common.Models;

namespace Nttb.Domain.Game.ValueObjects;

public class GameId : ValueObject
{
    public Guid Value { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private GameId(Guid value)
    {
        Value = value;
    } 

    public static GameId CreateUnique()
    {
        return new GameId(Guid.NewGuid());
    }
}