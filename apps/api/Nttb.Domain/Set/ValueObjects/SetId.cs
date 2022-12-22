using Nttb.Domain.Common.Models;

namespace Nttb.Domain.Set.ValueObjects;

public class SetId : ValueObject
{
    public Guid Value { get; }

    public SetId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}