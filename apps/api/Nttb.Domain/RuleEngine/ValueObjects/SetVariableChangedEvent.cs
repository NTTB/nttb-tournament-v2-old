using Nttb.Domain.Common.Models;

namespace Nttb.Domain.RuleEngine.ValueObjects;

public class SetVariableChangedEvent<T> : ValueObject
{
    public SetVariableChangedEvent(DateTime on, T value)
    {
        On = on;
        Value = value;
    }

    public DateTime On { get; }
    public T Value { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return On;
        yield return Value;
    }
}