namespace Nttb.Domain.Old.Views;

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