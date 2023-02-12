using Nttb.Domain.Views;

namespace Nttb.Domain.RuleEngines;

/// <summary>
///     A interface of a rule engine.
/// </summary>
public interface IRuleEngine
{
    /// <summary>
    ///     The unique identifier of the rule engine.
    /// </summary>
    public RuleEngineId Id { get; }

    /// <summary>
    ///     The constants that are required for sets in this rule engine.
    /// </summary>
    public IEnumerable<ConstantDefinition> RequiredConstants { get; }

    /// <summary>
    ///     The variables that are required for sets in this rule engine.
    /// </summary>
    public IEnumerable<VariableDefinition> RequiredVariables { get; }

    /// <summary>
    ///     The types of cards a referee can give to a participant.
    /// </summary>
    public IEnumerable<CardColor> CardColors { get; }
    
    // public IEnumerable<CountDownClock>
}