namespace Nttb.Domain.RuleEngines;

/// <summary>
///     The rule engine for the ITTF rules at the start of 2023.
/// </summary>
public class RuleEngineIttf2023 : IRuleEngine
{
    /// <inheritdoc />
    public RuleEngineId Id => RuleEngineId.Ittf2023;

    /// <inheritdoc />
    public IEnumerable<ConstantDefinition> RequiredConstants => new ConstantDefinition[]
    {
        new("BestOf", ValueType.Integer)
    };

    /// <inheritdoc />
    public IEnumerable<VariableDefinition> RequiredVariables => new VariableDefinition[]
    {
        new("ExpeditePlay", ValueType.Boolean)
    };

    /// <inheritdoc />
    public IEnumerable<CardColor> CardColors => new CardColor[]
    {
        // A card indicating a warning.
        // Having two of these is not the same as having a "Red" or "YellowRed" card.
        new("Yellow"),

        // A card indicating a warning and has consequences (point awarded to opponent as penalty).
        // Under the ITTF/NTTB rules this card given be given twice at most (depends on the specific).
        // Having two of these is not the same as having a "Red" card. 
        new("YellowRed"),

        // A card indicating a violation
        new("Red")
    };
}