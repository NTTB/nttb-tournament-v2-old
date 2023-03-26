namespace Nttb.Domain.Old.RuleEngines;

/// <summary>
///     A definition of a constant. Must be set before the set can be played and can NEVER change.
/// </summary>
/// <param name="Name">Name of the constant</param>
/// <param name="ValueType">The type of value</param>
public record ConstantDefinition(string Name, ValueType ValueType);