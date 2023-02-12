namespace Nttb.Domain;

/// <summary>
/// Describes the sides of the table tennis court, we use the referee's perspective to determine the side.
/// </summary>
public enum PlaySide
{
    /// <summary>
    /// Playing left from the referee.
    /// </summary>
    Left = 0,
    
    /// <summary>
    /// Playing right from the referee.
    /// </summary>
    Right = 1
}