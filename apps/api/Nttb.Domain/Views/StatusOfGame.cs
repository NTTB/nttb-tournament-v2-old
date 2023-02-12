using Nttb.Domain.Views;

namespace Nttb.Domain.Set;

/// <summary>
/// Describes the status of a game.
/// </summary>
public enum StatusOfGame
{
    /// <summary>
    ///     The game has not yet started or is not tracked.
    /// </summary>
    NotStarted,

    /// <summary>
    ///     The game has started and is being played.
    /// </summary>
    Active,

    /// <summary>
    ///     The game has been paused for some reason. This can be due to a timeout but also due to the referee stopping the
    ///     game.
    /// </summary>
    /// <remarks>Not to be confused with a set that is <see cref="StatusOfSet.Halted"/></remarks>
    Paused,

    /// <summary>
    ///     The game is finished and the home team has won.
    /// </summary>
    HomeWon,

    /// <summary>
    ///     The game is finished and the away team has won.
    /// </summary>
    AwayWon,

    /// <summary>
    ///     The game is finished and the home team has won by walk over.
    /// </summary>
    HomeWalkOver,

    /// <summary>
    ///     The game is finished and the away team has won by walk over.
    /// </summary>
    AwayWalkOver
}