namespace Nttb.Domain.RuleEngines;

/// <summary>
///     A definition of a variable. Must be set before the set can be played and can change during the set.
/// </summary>
/// <param name="Name">Name of the variable</param>
/// <param name="ValueType">The type of value</param>
public record VariableDefinition(string Name, ValueType ValueType);