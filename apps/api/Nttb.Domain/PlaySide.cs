namespace Nttb.Domain;

/// <summary>
/// Describes the sides of the table tennis court, we use the referee's perspective to determine the side.
/// The head referee always look North
/// </summary>
public enum PlaySide
{
    /// <summary>
    /// Playing west from the referee (so left if you are looking in the same direction as the head referee)
    /// </summary>
    West = -1,
    
    /// <summary>
    /// Playing east from the referee (so right if you are looking in the same direction as the head referee)
    /// </summary>
    East = 1
}