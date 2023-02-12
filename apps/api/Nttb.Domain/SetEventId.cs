namespace Nttb.Domain.Set.ValueObjects;

/// <summary>
/// The id of an event in a set.
/// </summary>
/// <param name="Value">A unique value</param>
public record SetEventId(Guid Value);