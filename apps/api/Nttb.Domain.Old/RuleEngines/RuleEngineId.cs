namespace Nttb.Domain.Old.RuleEngines;

/// <summary>
///     The id of a rule engine.
/// </summary>
/// <param name="Value">The value of the id</param>
public record RuleEngineId(string Value)
{
    /// <summary>
    ///     No rule engine was provided.
    /// </summary>
    public static readonly RuleEngineId None = new(string.Empty);

    /// <summary>
    ///     The id of the rule engine for the ITTF rules at the start of 2023.
    /// </summary>
    public static readonly RuleEngineId Ittf2023 = new("ITTF/2023");

    /// <summary>
    ///     The id of the rule engine for the NTTB rules at the start of 2023.
    /// </summary>
    public static readonly RuleEngineId Nttb2023 = new("NTTB/2023");
}