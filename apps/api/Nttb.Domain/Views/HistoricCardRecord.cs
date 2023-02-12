using Nttb.Domain.Player.ValueObjects;

namespace Nttb.Domain.Set;

/// <summary>
/// A record of a card that was given to a participant prior to the set a.
/// </summary>
public class HistoricCardRecord
{
    /// <summary>
    /// The participant that was given the card.
    /// </summary>
    public required ParticipantId Participant { get; init; }
    
    /// <summary>
    /// The color of the card.
    /// </summary>
    public required CardColor Color { get; init; }
}