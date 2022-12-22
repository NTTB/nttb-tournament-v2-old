using Nttb.Domain.Common.Models;
using Nttb.Domain.Set.ValueObjects;

namespace Nttb.Domain.RuleEngine.ValueObjects;

public class RuleEngineId : ValueObject
{
    public RuleEngineId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}