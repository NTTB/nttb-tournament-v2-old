using Nttb.Domain.Common.Models;

namespace Nttb.Domain.Phase.ValueObjects;

public class PhaseId : ValueObject
{
    public PhaseId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}