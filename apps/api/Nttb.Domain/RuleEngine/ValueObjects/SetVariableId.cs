using Nttb.Domain.Common.Models;
using Nttb.Domain.Set.ValueObjects;

namespace Nttb.Domain.RuleEngine.ValueObjects;

public class SetVariableId : ValueObject
{
    public SetVariableId(SetId setId, string name)
    {
        SetId = setId;
        Name = name;
    }

    public SetId SetId { get; }
    public string Name { get; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return SetId;
        yield return Name;
    }
}