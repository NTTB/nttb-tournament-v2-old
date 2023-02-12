namespace Nttb.Domain.Set;

/// <summary>
/// The color of a card.
/// </summary>
public enum CardColor
{
    /// <summary>
    /// A card indicating a warning.
    /// </summary>
    Yellow,
    
    /// <summary>
    /// A card indicating a violation
    /// </summary>
    Red,
    
    // TODO: Do we need another card to indicate an eviction?
    // We talked about a "YellowRed" and a "RedRed" card.
}