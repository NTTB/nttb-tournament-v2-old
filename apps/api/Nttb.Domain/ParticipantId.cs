namespace Nttb.Domain.Player.ValueObjects;

/// <summary>
/// The id of a participant in a set. The participant id of a player/coach/non-player is shared throughout the tournament.
/// </summary>
/// <param name="Value">The value of the id</param>
public record ParticipantId(Guid Value);