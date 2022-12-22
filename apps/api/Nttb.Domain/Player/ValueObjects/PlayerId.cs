using Nttb.Domain.Common.Models;

namespace Nttb.Domain.Player.ValueObjects;

public class PlayerId : ValueObject
{
    public Guid Value { get; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private PlayerId(Guid value)
    {
        Value = value;
    }
    
    public static PlayerId CreateUnique()
    {
        return new PlayerId(Guid.NewGuid());
    }
    
    /// <summary>
    /// An empty player id is used to represent a player that is not yet assigned to a game.
    /// </summary>
    public static PlayerId Undefined => new PlayerId(Guid.Empty);
}