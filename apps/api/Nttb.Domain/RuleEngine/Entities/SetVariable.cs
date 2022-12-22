using Nttb.Domain.Common.Models;
using Nttb.Domain.RuleEngine.ValueObjects;

namespace Nttb.Domain.RuleEngine.Entities;

public class SetVariable<T> : Entity<SetVariableId>
{
    public SetVariable(SetVariableId id, SetVariableChangedEvent<T> events) : base(id)
    {
        Events = events;
    }
    
    public SetVariableChangedEvent<T> Events { get; }
}